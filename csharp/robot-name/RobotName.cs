using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotName
{
    public class Robot
    {
        #region Static
        
        private static void GeneratePoolOfNames()
        {
            foreach (var letter1 in Enumerable.Range('A', 26))
            {
                foreach (var letter2 in Enumerable.Range('A', 26))
                {
                    foreach (var number in Enumerable.Range(100, 899))
                    {
                        var poolName = _stringBuilder
                            .Append( (char)letter1 )
                            .Append( (char)letter2 )
                            .Append( number )
                            .ToString();
                        
                        _names.Add(poolName);
                    }
                }   
            }
        }
        
        private static HashSet<string> _names = new HashSet<string>();

        private static StringBuilder _stringBuilder = new StringBuilder();

        private static readonly int LIMIT = 676_000;
        
        #endregion
        
        private Random _random = new Random((int)DateTime.Now.Ticks);
    
        private string _name;
    
        public string Name => _name ?? AssignName();
    
        public void Reset()
        {
            _names.Remove(_name);
            _name = null;
        }

        private string AssignName()
        {
            do
            {
                if (Math.Abs(LIMIT - _names.Count) < 1000)
                    throw new Exception("Name limit almost reached");
                _name = GenerateName();
            } 
            while (!_names.Add(_name));
            return _name;
        }
        
        private string GenerateName() =>
            new StringBuilder()
                .Append(GenerateChars(2))
                .Append(GenerateNumbers(3))
                .ToString();
        
        private char[] GenerateChars(int amount) =>
            new char[amount]
                .Select(_ => (char)_random.Next('A', 'Z')).ToArray();
        
        private string GenerateNumbers(int amount) =>
            $"{_random.Next((int)Math.Pow(10, amount - 1), (int)Math.Pow(10, amount))}";
    }
}

