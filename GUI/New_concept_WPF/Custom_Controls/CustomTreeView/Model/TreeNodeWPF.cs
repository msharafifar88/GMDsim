using persistent.common;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;

namespace GUI.New_concept_WPF
{
    public class TreeNodeWPF : INotifyPropertyChanged
    {
        private string elementName;
        private ImageSource elementIcon;
        public ItemEnum enumitem;
        private ObservableCollection<TreeNodeWPF> subFiles;

        public ObservableCollection<TreeNodeWPF> SubFiles
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
        public ItemEnum EnumItem
        {
            get { return enumitem; }
            set
            {
                enumitem = value;
                RaisedOnPropertyChanged("EnumItem");
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

