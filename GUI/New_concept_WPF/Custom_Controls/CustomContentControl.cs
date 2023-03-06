using System.Windows.Controls;
using persistent;
using persistent.enumeration;

namespace GUI.New_concept_WPF
{
    class CustomContentControl : ContentControl
    {
        private static Case currentCase = null;
        private static TypeOfInput TypeOfInput = TypeOfInput.Local;
        private Case cases;
      
        public long indexControl;

        public CustomContentControl(Case newCase)
        {
            this.cases = newCase;
            this.indexControl = newCase.code;
           
        }

        public void setCase(Case newCase)
        {
            this.cases = newCase;
        }

        public Case getCase()
        {
            return this.cases;
        }

        public static Case getCurrentCase()
        {
            return currentCase;
        }

        public static void setCurrentCase(Case rightCase)
        {
            currentCase = rightCase;
        }

        /// Enum
        /// 

        public static void setTypeOfInput(TypeOfInput typeOfInput)
        {
            TypeOfInput = typeOfInput;
        }

        public static TypeOfInput GetTypeOfInput()
        {
            return TypeOfInput;
        }



    }
}
