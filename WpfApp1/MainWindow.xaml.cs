using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Szakasz> tarolas = new List<Szakasz>();
        public MainWindow()
        {
            InitializeComponent();

            string[] sorok = File.ReadAllLines("kektura.txt");
            int sorszam = 1;
            for (int i = 0; i < sorok.Length; i++)
            {
                string[] feloszt = sorok[i].Split(';');

                Szakasz betoltes = new Szakasz(sorszam, feloszt[0], Convert.ToDouble(feloszt[1]), Convert.ToInt32(feloszt[2]), Convert.ToInt32(feloszt[3]));
                tarolas.Add(betoltes);
                sorszam++;
            }
            dgTablazat.ItemsSource=tarolas;
        }

        private void btnSzakaszokSzama_Click(object sender, RoutedEventArgs e)
        {
            int szakaszokSzama = tarolas.Count;
            MessageBox.Show($"A táblázat {szakaszokSzama} sorból áll!");
        }

        private void btnTeljesitesSzerint_Click(object sender, RoutedEventArgs e)
        {
            int beirtErtek = Convert.ToInt32(txtTeljesitesiIdo.Text);
            var teljIdoSzerint = tarolas.Where(x => x.TeljesitesVarhatoIdeje<=beirtErtek).ToList();
            dgTablazat.ItemsSource = teljIdoSzerint;
            lblTeljesitesiIdoSzerint.Content = dgTablazat.Items.Count;
        }

        private void btnPilisSzures_Click(object sender, RoutedEventArgs e)
        {
            double atlTeljIdo = tarolas.Where(x => x.UtvonalLeiras.Contains("Pilis")).Average(x => x.TeljesitesVarhatoIdeje);
            MessageBox.Show($"Átlagosan {Math.Round(atlTeljIdo)} perc");
        }

        private void btnLeghosszabb_Click(object sender, RoutedEventArgs e)
        {
            var leghosszabb = tarolas.OrderByDescending(x => x.TavolsagKm).First();
            MessageBox.Show($"{leghosszabb.UtvonalLeiras};{leghosszabb.TavolsagKm};{leghosszabb.TeljesitesVarhatoIdeje}");
        }

        private void btnJelentes_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllLines("utvonal.txt", tarolas.Select(x=>$"{x.UtvonalLeiras},{x.TavolsagKm},{x.TengerszintFelettiMagassag},{x.Nehezseg}"));
            MessageBox.Show("Sikeres mentés!");
        }
    }
}
