using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleApp3
{
    class AnnoucementEqualityComparer : IEqualityComparer<Annoucement>
    {
        public bool Equals([AllowNull] Annoucement x, [AllowNull] Annoucement y)
        {
            if(x != null && y != null) { 
                if (x.Id == y.Id && x.Title == y.Title)
                    return true;
            }
            return false;
        }

        public int GetHashCode([DisallowNull] Annoucement obj)
        {
            return $"{obj.Id}:{obj.Title}".GetHashCode(); 
        }
    }
}
