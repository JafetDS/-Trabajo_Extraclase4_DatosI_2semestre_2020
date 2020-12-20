using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Arbol.ViewModels
{
    public class ArbolAA
    {
        

        public String Con;

        public Editor edit;

        private class Node
        {
            // node internal data
            internal int level;
            internal Node left;
            internal Node right;

            // user data
            internal int key;
            internal int value;

            // constuctor for the sentinel node
            internal Node()
            {
                this.level = 0;
                this.left = this;
                this.right = this;
            }

            // constuctor for regular nodes (that all start life as leaf nodes)
            internal Node(int key, int value, Node sentinel)
            {
                this.level = 1;
                this.left = sentinel;
                this.right = sentinel;
                this.key = key;
                this.value = value;
            }
        }
     

        public class AATree
        {
            Node root;
            Node sentinel;
            Node deleted;
            int elements;
            public List<int> lista;
            public AATree()
            {
                root = sentinel = new Node();
                deleted = null;
                elements = 0;
                lista = new List<int>();
        }

            private void Skew(ref Node node)
            {
                if (node.level == node.left.level)
                {
                    // rotate right
                    Node left = node.left;
                    node.left = left.right;
                    left.right = node;
                    node = left;
                }
            }

            private void Split(ref Node node)
            {
                if (node.right.right.level == node.level)
                {
                    // rotate left
                    Node right = node.right;
                    node.right = right.left;
                    right.left = node;
                    node = right;
                    node.level++;
                }
            }

            public void Insert(int data,int dato)
            {
                Insert(ref this.root, data, dato );
            }

            private bool Insert(ref Node node, int key, int value)
            {
                
                if (node == sentinel)
                {
                    node = new Node(key, value, sentinel);
                    return true;
                }

                int compare = key.CompareTo(node.key);
                if (compare < 0)
                {
                    if (!Insert(ref node.left, key, value))
                        return false;
                }
                else if (compare > 0)
                {
                    if (!Insert(ref node.right, key, value))
                        return false;
                }
                else
                {
                    return false;
                }

                Skew(ref node);
                Split(ref node);

                return true;
            }

            public void Delete(int key)
            {
                Delete(ref this.root, key);
            }
      
            private bool Delete(ref Node node, int key)
            {
                if (node == sentinel)
                {
                    return (deleted != null);
                }

                int compare = key.CompareTo(node.key);
                if (compare < 0)
                {
                    if (!Delete(ref node.left, key))
                        return false;
                }
                else
                {
                    if (compare == 0)
                        deleted = node;
                    if (!Delete(ref node.right, key))
                        return false;
                }

                if (deleted != null)
                {
                    deleted.key = node.key;
                    deleted.value = node.value;
                    deleted = null;
                    node = node.right;
                }
                else if (node.left.level < node.level - 1
                      || node.right.level < node.level - 1)
                {
                    --node.level;
                    if (node.right.level > node.level)
                        node.right.level = node.level;
                    Skew(ref node);
                    Skew(ref node.right);
                    Skew(ref node.right.right);
                    Split(ref node);
                    Split(ref node.right);
                }

                return true;
            }
            public String getTreeCode()
            {
                int range = 1;
                int c = 0;
              
                lista.Add(this.root.key);
                String codigo = String.valueOf(this.root.getData());
                String subcodigo;
                int top = 1;

                while (top < this.elements)
                {
                    codigo += "/";
                    subcodigo = "";
                    for (int i = c; i < range + c; i++)
                    {

                        if (lista.get(i) != null)
                        {

                            if (lista.FindGet(i).getLeft() != null)
                            {
                                lista.Add(lista.get(i).getLeft());
                                subcodigo += ",";
                                subcodigo += String.valueOf(lista.get(i).getLeft().getData());
                                top += 1;
                            }
                            else
                            {
                                lista.add(null);
                                subcodigo += ",";
                                subcodigo += "null";
                            }


                            if (lista.get(i).getRight() != null)
                            {
                                lista.add(lista.get(i).getRight());
                                subcodigo += ",";
                                subcodigo += String.valueOf(lista.get(i).getRight().getData());
                                top += 1;
                            }
                            else
                            {
                                lista.add(null);
                                subcodigo += ",";
                                subcodigo += "null";

                            }
                        }
                        else
                        {
                            lista.add(null);
                            subcodigo += ",";
                            subcodigo += "null";


                            lista.add(null);
                            subcodigo += ",";
                            subcodigo += "null";


                        }
                    }

                    c = range + c;
                    range = range * 2;

                    codigo += subcodigo.substring(1);
                }


                return codigo;
            }




        }
    }
}