using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Arbol.ViewModels
{
    public class ArbolBinarioOrdenado
    {
        public List<int> list = new List<int>();

        public String Con;
        
        public Editor edit;

        public class Nodo
        {
            public int info;
            public Nodo izq, der;
        }
        Nodo raiz;

        public ArbolBinarioOrdenado(Editor editp)
        {
            raiz = null;
            edit = editp;
            Con = " ";
        }

        public void Insertar(int info)
        {
            this.list.Add(info);
            this.raiz = Insertar(list.ToArray(),this.raiz, 0);

        }

        public Nodo Insertar(int[] arr, Nodo root, int i)
        {
            if (i < arr.Length)
            {
                Nodo temp = new Nodo();
                temp.info = arr[i];
                root = temp;


                root.izq = Insertar(arr, root.izq, 2 * i + 1);


                root.der = Insertar(arr, root.der, 2 * i + 2);
            }
            return root;
        }

        private void ImprimirPre(Nodo reco)
        {
            if (reco != null)
            {
                Con = reco.info.ToString();
                edit.Text = edit.Text + Con + "-";
                ImprimirPre(reco.izq);
                ImprimirPre(reco.der);

           
            }
        }

        public void ImprimirPre()
        {
            ImprimirPre(raiz);

   
        }

        private void ImprimirEntre(Nodo reco)
        {
            if (reco != null)
            {
                ImprimirEntre(reco.izq);

                Con = reco.info.ToString();
                edit.Text = edit.Text + Con + "-";
                ImprimirEntre(reco.der);


            }
        }

        public void ImprimirEntre()
        {
            ImprimirEntre(raiz);


        }


        private void ImprimirPost(Nodo reco)
        {
            if (reco != null)
            {
                ImprimirPost(reco.izq);
                ImprimirPost(reco.der);

                Con = reco.info.ToString();
                edit.Text = edit.Text + Con + "-";
            }
        }


        public void ImprimirPost()
        {
            ImprimirPost(raiz);
            

        }

    }
}
