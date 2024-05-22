using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace _2024_02_24_Kepnezegeto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Photos photos;
        string path = "H:/SZAAAAAAAAAA/K-PESBEDADND-WPF/2024_04_24_Kepnezegeto/2024_04_24_Kepnezegeto/images";
        ICollectionView myView;
        int mode = 1;



        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded; //this.Loaded += TAB TAB
            lstBox1.Visibility = Visibility.Visible;
            lstBox2.Visibility = Visibility.Collapsed;
            lstBox3.Visibility = Visibility.Collapsed;
            lstBox1.SelectedIndex = 0;
            fel_balra.IsEnabled = true;
            le_jobbra.IsEnabled = true;
            GombCheck();
            mode = 1;
        }

        public void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var files = new DirectoryInfo(path).GetFiles().ToList();
            photos = new Photos(files);
            this.DataContext = photos;  // Az ablakohoz hozzáadom az összes képet használatra.

            myView = CollectionViewSource.GetDefaultView(photos);
            this.DataContext = myView;

            //Nézi a mappa tartalmát, hogy kerül-e bele új kép.
            FileSystemWatcher fsw = new FileSystemWatcher(path);
            fsw.Created += FswCreated;
            fsw.EnableRaisingEvents = true;
            GombCheck();

        }

        private void FswCreated(object sender, FileSystemEventArgs e)
        {
            //Ha új képet töltünk be
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                //Diszépcserrel ellenőrzött módon tud a két szál között kommunikálni.
                Dispatcher.Invoke(new ThreadStart(() =>
                {
                    FileInfo fs = new FileInfo(e.FullPath);
                    // Ez külön szálon fut.Ezért ezt nem támogatja. Dispécsert kell használni a két szál között.
                    photos.Insert(0, fs);
                }));
            }
            GombCheck();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            myView.SortDescriptions.Add(
                new SortDescription("Name", ListSortDirection.Descending));
            GombCheck();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            myView.SortDescriptions.Add(
                new SortDescription("LastAccessTime", ListSortDirection.Descending));
            GombCheck();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GombCheck();
            lstBox1.Visibility = Visibility.Visible;
            lstBox2.Visibility = Visibility.Collapsed;
            lstBox3.Visibility = Visibility.Collapsed;
            lstBox1.SelectedIndex = 0;
            lstBox1.ScrollIntoView(lstBox1.SelectedItem);
            fel_balra.IsEnabled = true;
            le_jobbra.IsEnabled = true;
            GombCheck();
            mode = 1;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GombCheck();
            lstBox1.Visibility = Visibility.Hidden;
            lstBox2.Visibility = Visibility.Visible;
            lstBox3.Visibility = Visibility.Collapsed;
            lstBox2.SelectedIndex = 0;
            lstBox2.ScrollIntoView(lstBox2.SelectedItem);
            fel_balra.IsEnabled = true;
            le_jobbra.IsEnabled = true;
            GombCheck();
            mode = 2;
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            lstBox1.Visibility = Visibility.Hidden;
            lstBox2.Visibility = Visibility.Collapsed;
            lstBox3.Visibility = Visibility.Visible;
            fel_balra.IsEnabled = false;
            le_jobbra.IsEnabled = false;
            GombCheck();
            mode = 3;
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //fel
            if (mode == 2)
            {
                int i = lstBox2.SelectedIndex;
                if (i == -1 || i == 0)
                {
                    return;
                }
                lstBox2.SelectedIndex = i - 1;
                lstBox2.ScrollIntoView(lstBox2.SelectedItem);
            }
            else if (mode == 1)
            {
                int i = lstBox1.SelectedIndex;
                if (i == -1 || i == 0)
                {
                    return;
                }
                lstBox1.SelectedIndex = i - 1;
                lstBox1.ScrollIntoView(lstBox1.SelectedItem);
            }
            GombCheck();
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            //le
            if (mode == 2)
            {
                int i = lstBox2.SelectedIndex;
                if (i == -1 || i == lstBox2.Items.Count - 1)
                {
                    return;
                }
                lstBox2.SelectedIndex = i + 1;
                lstBox2.ScrollIntoView(lstBox2.SelectedItem);
            }
            else if (mode == 1) 
            {
                int i = lstBox1.SelectedIndex;
                if (i == -1 || i == lstBox1.Items.Count - 1)
                {
                    return;
                }
                lstBox1.SelectedIndex = i + 1;
                lstBox1.ScrollIntoView(lstBox1.SelectedItem);
            }
            GombCheck();
        }
        private void GombCheck()
        {
            if (mode == 2)
            {
                int i = lstBox2.SelectedIndex;
                fel_balra.IsEnabled = (i > 0);
                le_jobbra.IsEnabled = (i < lstBox2.Items.Count - 1);
            }
            else if (mode == 1)
            {
                int i = lstBox1.SelectedIndex;
                fel_balra.IsEnabled = (i > 0);
                le_jobbra.IsEnabled = (i < lstBox1.Items.Count - 1);
            }

        }
    }
}