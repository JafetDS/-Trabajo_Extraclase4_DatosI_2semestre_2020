using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Arbol.ViewModels
{
    public class ArbolBinarioOrdenado
    {  

        public String Con;
        
        public Editor edit;

        class Nodo
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
            Nodo nuevo;
            nuevo = new Nodo();
            nuevo.info = info;
            nuevo.izq = null;
            nuevo.der = null;
            if (raiz == null)
                raiz = nuevo;
            else
            {
                Nodo anterior = null, reco;
                reco = raiz;
                while (reco != null)
                {
                    anterior = reco;
                    if (info < reco.info)
                        reco = reco.izq;
                    else
                        reco = reco.der;
                }
                if (info < anterior.info)
                    anterior.izq = nuevo;
                else
                    anterior.der = nuevo;
            }
        }


        private void ImprimirPre(Nodo reco)
        {
            if (reco != null)
            {
                Console.Write(reco.info + " ");
                ImprimirPre(reco.izq);
                ImprimirPre(reco.der);
                Con = reco.ToString();
                edit.Text = edit.Text + Con;
           
            }
        }

        public void ImprimirPre()
        {
            ImprimirPre(raiz);
            Console.WriteLine();
   
        }

        private void ImprimirEntre(Nodo reco)
        {
            if (reco != null)
            {
                ImprimirEntre(reco.izq);
                Console.Write(reco.info + " ");
                ImprimirEntre(reco.der);
                Con = reco.ToString();
                edit.Text = edit.Text + Con;

            }
        }

        public void ImprimirEntre()
        {
            ImprimirEntre(raiz);
            Console.WriteLine();

        }


        private void ImprimirPost(Nodo reco)
        {
            if (reco != null)
            {
                ImprimirPost(reco.izq);
                ImprimirPost(reco.der);
                Console.Write(reco.info + " ");
                Con = reco.ToString();
                edit.Text = edit.Text + Con;
            }
        }


        public void ImprimirPost()
        {
            ImprimirPost(raiz);
            

        }

    }
}
