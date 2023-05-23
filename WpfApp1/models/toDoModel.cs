using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.models
{
    internal class toDoModel: INotifyPropertyChanged 
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        private bool isDone;

        public bool IsDone
        {
            get { return isDone; }  
            set { isDone = value; 
                if(isDone == value)
                {
                    return;
                }
                isDone = value;
                OnPrepertyChanged("IsDone");
            }
        }
        private string _text;

        

        public string Text
        {
            get { return _text; }
            set { _text = value; 
                if(_text == value)
                {
                    return;
                }
                _text = value;
                OnPrepertyChanged("Text");
            }
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPrepertyChanged(string propertyName ="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            
        }
    }
}
