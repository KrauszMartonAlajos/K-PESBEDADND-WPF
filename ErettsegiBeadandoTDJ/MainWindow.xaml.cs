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

namespace ErettsegiBeadandoTDJ
{
    public partial class MainWindow : Window
    {
        Photos photos;
        string path = "H:/12.C/Program/2024_04_24_Kepnezegeto/images";
        ICollectionView myView;
        int nezet = 0;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            LepkedGombMutat();
        }

        public void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var files = new DirectoryInfo(path).GetFiles().ToList();
            photos = new Photos(files);
            this.DataContext = photos;

            myView = CollectionViewSource.GetDefaultView(photos);
            this.DataContext = myView;

            FileSystemWatcher fsw = new FileSystemWatcher(path);
            fsw.Created += FswCreated;
            fsw.EnableRaisingEvents = true;
        }

        private void FswCreated(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                Dispatcher.Invoke(new ThreadStart(() =>
                {
                    FileInfo fs = new FileInfo(e.FullPath);
                    photos.Insert(0, fs);
                }));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myView.SortDescriptions.Add(
                new SortDescription("Name", ListSortDirection.Descending));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            myView.SortDescriptions.Add(
                new SortDescription("Name", ListSortDirection.Descending));
        }

        private void NezetBetolt()
        {
            if (nezet == 1)
            {
                Egykepnezo.Visibility = Visibility.Visible;
                lstBox.Visibility = Visibility.Collapsed;
                Egymasalatt.Visibility = Visibility.Collapsed;
            }
            else if (nezet == 2)
            {
                Egykepnezo.Visibility = Visibility.Collapsed;
                lstBox.Visibility = Visibility.Visible;
                Egymasalatt.Visibility = Visibility.Collapsed;
            }
            else if (nezet == 3)
            {
                Egykepnezo.Visibility = Visibility.Collapsed;
                lstBox.Visibility = Visibility.Collapsed;
                Egymasalatt.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            lepked = 1;
            nezet = 1;
            NezetBetolt();
            LepkedGombMutat();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            lepked = 0;
            nezet = 2;
            NezetBetolt();
            LepkedGombMutat();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            lepked = 0;
            nezet = 3;
            NezetBetolt();
            LepkedGombMutat();

                Egykepnezo.Items.Clear(); // Töröljük az összes előző elemet az Egykepnezo ListBox-ból

                // Adjon hozzá minden képet és hozzájuk tartozó információkat az Egykepnezo ListBox-hoz
                foreach (var photo in photos)
                {
                    string imagePath = Path.Combine(path, photo.Name);
                    if (File.Exists(imagePath))
                    {
                        BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
                        Image imageControl = new Image();
                        imageControl.Source = bitmap;

                        // Információk hozzáadása
                        StackPanel stackPanel = new StackPanel();
                        TextBlock nameTextBlock = new TextBlock();
                        nameTextBlock.Text = "Név: " + photo.Name;
                        stackPanel.Children.Add(nameTextBlock);

                        TextBlock lastAccessTextBlock = new TextBlock();
                        lastAccessTextBlock.Text = "Utolsó hozzáférés ideje: " + photo.LastAccessTime.ToString();
                        stackPanel.Children.Add(lastAccessTextBlock);

                        // Kép és információk hozzáadása az Egykepnezo ListBox-hoz
                        StackPanel panel = new StackPanel();
                        panel.Children.Add(imageControl);
                        panel.Children.Add(stackPanel);
                        Egymasalatt.Items.Add(panel);
                    
                }
            }

        }

        int lepked = 0;

        private void LepkedGombMutat()
        {
            lepelore.Visibility = Visibility.Visible;
            lephatra.Visibility = Visibility.Visible;
            if (lepked == 0)
            {
                lepelore.Visibility = Visibility.Collapsed;
                lephatra.Visibility = Visibility.Collapsed;
            }
            else if (lepked == 1)
            {
                lepelore.Visibility = Visibility.Visible;
                lephatra.Visibility = Visibility.Collapsed;
            }
            else if (lepked == photos.Count)
            {
                lepelore.Visibility = Visibility.Collapsed;
                lephatra.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            LepkedGombMutat();
            lepked -= 1;
            SetImageBackground(lepked);
            LepkedGombMutat();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            LepkedGombMutat();
            lepked += 1;
            SetImageBackground(lepked);
            LepkedGombMutat();
        }

        private void SetImageBackground(int lepked)
        {
            string relativePathPng = $"images/image-{lepked}.png";
            string relativePathJpg = $"images/image-{lepked}.jpg";

            DisplayedImage displayedImage = new DisplayedImage();

            if (File.Exists(relativePathPng))
            {
                displayedImage.Path = relativePathPng;
            }
            else if (File.Exists(relativePathJpg))
            {
                displayedImage.Path = relativePathJpg;
            }
            else
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string fullPathPng = Path.Combine(basePath, "images", $"image-{lepked}.png");
                string fullPathJpg = Path.Combine(basePath, "images", $"image-{lepked}.jpg");

                if (File.Exists(fullPathPng))
                {
                    displayedImage.Path = fullPathPng;
                }
                else if (File.Exists(fullPathJpg))
                {
                    displayedImage.Path = fullPathJpg;
                }
                else
                {
                    MessageBox.Show("Nem található a kép sem PNG, sem JPG formátumban.");
                    return;
                }
            }

            if (photos != null && lepked >= 0 && lepked < photos.Count)
            {
                var selectedPhoto = photos[lepked];
                displayedImage.Name = selectedPhoto.Name;
                displayedImage.LastAccessTime = selectedPhoto.LastAccessTime;
                displayedImage.Description = $"Név: {selectedPhoto.Name}, Utolsó hozzáférés ideje: {selectedPhoto.LastAccessTime}";

                // A kép elérési útjának beállítása a displayedImage-ben
                displayedImage.Path = selectedPhoto.FullName;
            }


            // Hozzáadás az Egykepnezo ItemsSource-hoz
            Egykepnezo.Items.Clear();
            Egykepnezo.Items.Add(displayedImage);
        }



        private bool TrySetBackgroundImage(string imagePath, UriKind uriKind)
        {
            try
            {
                if (uriKind == UriKind.Relative)
                {
                    string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath);
                    if (!File.Exists(fullPath))
                    {
                        return false;
                    }
                }
                else if (uriKind == UriKind.Absolute)
                {
                    if (!File.Exists(imagePath))
                    {
                        return false;
                    }
                }

                Uri imageUri = new Uri(imagePath, uriKind);
                Egykepnezo.Background = new ImageBrush(new BitmapImage(imageUri));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
