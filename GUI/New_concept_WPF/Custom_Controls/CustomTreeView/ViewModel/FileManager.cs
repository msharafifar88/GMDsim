using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;

namespace GUI.New_concept_WPF
{
    public class FileManager : INotifyPropertyChanged
    {
        private string elementName;
        private ImageSource elementIcon;
        private ObservableCollection<FileManager> subFiles;

        public ObservableCollection<FileManager> SubFiles
        {
            get { return subFiles; }
            set
            {
                subFiles = value;
                RaisedOnPropertyChanged("SubFiles");
            }
        }

        public string ElementName
        {
            get { return elementName; }
            set
            {
                elementName = value;
                RaisedOnPropertyChanged("ElementName");
            }
        }

        public ImageSource ElementIcon
        {
            get { return elementIcon; }
            set
            {
                elementIcon = value;
                RaisedOnPropertyChanged("ElementIcon");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }
    }
}
