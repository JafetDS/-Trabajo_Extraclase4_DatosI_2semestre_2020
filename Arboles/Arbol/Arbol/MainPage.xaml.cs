using Arbol.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Arbol
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public String text;
        public Label label;
        public StackLayout Stack;
        public Grid grid;
        public Entry entry;
        public int L;
        public int c;
        public Editor edit;
        public ArbolBinarioOrdenado arbole;

        public MainPage()
        {

            edit = new Editor();
            
            arbole = new ArbolBinarioOrdenado(edit);
            this.L = 1;
            this.c = 0;
            entry = new Entry();
            grid = new Grid();
            Stack = new StackLayout();
            Title = "Code Button Click";

          //  this.label.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));

            entry.Keyboard = Keyboard.Numeric;

            Button button = new Button
            {
                Text = "Insertar",
            };
            button.Clicked += async (sender, args) =>  Cambio();

            Button button1 = new Button
            {
                Text = "preOrder",
            };
            button1.Clicked += async (sender, args) => Cambio1();

            Button button2 = new Button
            {
                Text = "InOrder",
            };
            button2.Clicked += async (sender, args) => Cambio2();

            Button button3 = new Button
            {
                Text = "PosOrder",
            };
            button3.Clicked += async (sender, args) => Cambio3();



            Stack.Children.Add(entry);
            Stack.Children.Add(button);
            Stack.Children.Add(button1);
            Stack.Children.Add(button2);
            Stack.Children.Add(button3);
            Stack.Children.Add(grid);
            Stack.Children.Add(edit);
            create();

            

            Content = Stack;
   


            // InitializeComponent();
        }
        
            
      private async void Cambio()
       {

            Label lab = new Label();
            String text = entry.Text;
            lab.Text = text;
            lab.HorizontalOptions = LayoutOptions.Center;
            grid.Children.Add(lab, c, 0);
            this.arbole.Insertar(Int32.Parse(text));

            c = c + 1;
            if (c == L )
            {
                this.L = L * 2;
                create();       
            }



            //   this.arbole.Insertar(Int32.Parse(text));
        }

        private void create()
        {
   
            grid = new Grid();
            grid.HorizontalOptions = LayoutOptions.Center;
            for (int i = 0; i < this.L; i++)
            {

                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            Stack.Children.Add(grid);

            this.c = 0;
        }


        private async void Cambio1()
        {
            edit.Text = " ";
            this.arbole.ImprimirPre();
        }

        private async void Cambio2()
        {
            edit.Text = " ";
            this.arbole.ImprimirEntre();
        }

        private async void Cambio3()
        {
            edit.Text = " ";
            this.arbole.ImprimirPost();
        }
    }
}
