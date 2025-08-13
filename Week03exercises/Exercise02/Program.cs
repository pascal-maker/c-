using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using Ct.Ai.Models;

namespace Ct.Ai.Models
{
    class LibraryItems
    {
        static void Main(string[] args)
        {
            LibraryItem libraryitem = new DVD(8,"Scary Movie", 2002,120);
            libraryitem.PrintDetails();


            List<LibraryItem> libraryitems = new List<LibraryItem>
            {
                new Book(1,"Gobletoffire",2004,"j.k rowling"),
                new DVD(2,"scarymovie2",2006,220),
                new Magazine(3,"forbes",2025,1)
            };


            foreach (LibraryItem librarything in libraryitems)
            {
                librarything.PrintDetails();
            }


        }
    }
}
