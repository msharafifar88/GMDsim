using System.Collections.Generic;

namespace GUI.New_concept
{
    class RegisterCaseShapes
    {
        private Dictionary<string, int> register;
        internal RegisterCaseShapes()
        {
            register = new Dictionary<string, int>();
            register.Clear();
        }

        internal void setRegister(string obj)
        {

            if (!register.ContainsKey(obj))
            {
                register.Add(obj, 1);
            }
            else
            {
                register[obj] = register[obj] + 1;
            }
        }

        public int getRegister(string obj)
        {
            return register[obj];
        }
    }
}
