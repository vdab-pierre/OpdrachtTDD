using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OpdrachtTDD
{
    public class Persoon
    {
        private readonly List<string> voornamen;
        private static readonly Regex regex = new Regex(@".*\S.*");

        public Persoon(List<string> voornamen)
        {
            if (voornamen == null)
            {
                throw new ArgumentNullException();
            }

            if (voornamen.Count == 0)
            {
                throw new ArgumentException();
            }

            foreach(string voornaam in voornamen)
            {
                if (!regex.IsMatch(voornaam))
                {
                    throw new ArgumentException();
                }
            }

            for (int i = 0; i < voornamen.Count; i++)
            {
                for (int j = i + 1; j < voornamen.Count; j++)
                {
                    if (voornamen[i] == voornamen[j])
                    {
                        throw new ArgumentException();
                    }
                }
            } 

            this.voornamen = voornamen;
        }

        public override string ToString()
        {
            string lijst = "";
            foreach (string voornaam in voornamen)
            {
                lijst += $"{voornaam} ";
            }
            return lijst;
        }
    }
}
