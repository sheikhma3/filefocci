using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication2.Models;
namespace MvcApplication2.Models
{
    
    	


public abstract class ViewModelBase
{
    Database1Entities2 dbnew = new Database1Entities2();
    Database1Entities1 cx = new Database1Entities1();

    public List<tag> getalltag()
    {
        
        return cx.tags.ToList();

    }
    public List<ftag> getallftag()
    {

        return cx.ftags.ToList();

    }
    public List<userFTag> getallftag(int userid)
    {

        return dbnew.userFTags.Where(x => x.uid == userid).ToList();

    }
    public List<userCTag> getallctag(int userid)
    {

        return dbnew.userCTags.Where(x => x.uid == userid).ToList();

    }
    public List<ftagdetail> getallftagdetails()
    {

        return cx.ftagdetails.ToList();

    }
    public List<char> getalphabets(List<Contact> lc)
    {
        List<char> ll = new List<char>();
        List<char> l = new List<char>();
          foreach (var x in lc)
        {

            
                
                l.Add(x.Name[0]);
            
        }
        if(l.Contains('a')||l.Contains('A'))
        {
            ll.Add('A');
        }
        if (l.Contains('b') || l.Contains('B'))
        {
            ll.Add('B');
        }
        if (l.Contains('c') || l.Contains('C'))
        {
            ll.Add('C');
        }
        if (l.Contains('d') || l.Contains('D'))
        {
            ll.Add('D');
        }
        if (l.Contains('e') || l.Contains('E'))
        {
            ll.Add('E');
        }
        if (l.Contains('f') || l.Contains('F'))
        {
            ll.Add('F');
        }
        if (l.Contains('g') || l.Contains('G'))
        {
            ll.Add('G');
        }
        if (l.Contains('h') || l.Contains('H'))
        {
            ll.Add('H');
        }
        if (l.Contains('i') || l.Contains('I'))
        {
            ll.Add('I');
        }
        if (l.Contains('j') || l.Contains('J'))
        {
            ll.Add('J');
        } 
        if (l.Contains('k') || l.Contains('K'))
        {
            ll.Add('K');
        } if (l.Contains('l') || l.Contains('L'))
        {
            ll.Add('L');
        } if (l.Contains('m') || l.Contains('M'))
        {
            ll.Add('M');
        } if (l.Contains('n') || l.Contains('N'))
        {
            ll.Add('N');
        } if (l.Contains('o') || l.Contains('O'))
        {
            ll.Add('O');
        } if (l.Contains('p') || l.Contains('P'))
        {
            ll.Add('P');
        } if (l.Contains('q') || l.Contains('Q'))
        {
            ll.Add('Q');
        } if (l.Contains('r') || l.Contains('R'))
        {
            ll.Add('R');
        } if (l.Contains('s') || l.Contains('S'))
        {
            ll.Add('S');
        } if (l.Contains('t') || l.Contains('T'))
        {
            ll.Add('T');
        } if (l.Contains('u') || l.Contains('U'))
        {
            ll.Add('U');
        } if (l.Contains('v') || l.Contains('V'))
        {
            ll.Add('V');
        } if (l.Contains('w') || l.Contains('W'))
        {
            ll.Add('W');
        } if (l.Contains('x') || l.Contains('X'))
        {
            ll.Add('X');
        } if (l.Contains('y') || l.Contains('Y'))
        {
            ll.Add('Y');
        } if (l.Contains('z') || l.Contains('Z'))
        {
            ll.Add('Z');
        }
        return ll;
    }
    public List<char> getalphabetsnewdb(List<contact1> lc)
    {
        List<char> ll = new List<char>();
        List<char> l = new List<char>();
        foreach (var x in lc)
        {



            l.Add(x.firstName[0]);

        }
        if (l.Contains('a') || l.Contains('A'))
        {
            ll.Add('A');
        }
        if (l.Contains('b') || l.Contains('B'))
        {
            ll.Add('B');
        }
        if (l.Contains('c') || l.Contains('C'))
        {
            ll.Add('C');
        }
        if (l.Contains('d') || l.Contains('D'))
        {
            ll.Add('D');
        }
        if (l.Contains('e') || l.Contains('E'))
        {
            ll.Add('E');
        }
        if (l.Contains('f') || l.Contains('F'))
        {
            ll.Add('F');
        }
        if (l.Contains('g') || l.Contains('G'))
        {
            ll.Add('G');
        }
        if (l.Contains('h') || l.Contains('H'))
        {
            ll.Add('H');
        }
        if (l.Contains('i') || l.Contains('I'))
        {
            ll.Add('I');
        }
        if (l.Contains('j') || l.Contains('J'))
        {
            ll.Add('J');
        }
        if (l.Contains('k') || l.Contains('K'))
        {
            ll.Add('K');
        } if (l.Contains('l') || l.Contains('L'))
        {
            ll.Add('L');
        } if (l.Contains('m') || l.Contains('M'))
        {
            ll.Add('M');
        } if (l.Contains('n') || l.Contains('N'))
        {
            ll.Add('N');
        } if (l.Contains('o') || l.Contains('O'))
        {
            ll.Add('O');
        } if (l.Contains('p') || l.Contains('P'))
        {
            ll.Add('P');
        } if (l.Contains('q') || l.Contains('Q'))
        {
            ll.Add('Q');
        } if (l.Contains('r') || l.Contains('R'))
        {
            ll.Add('R');
        } if (l.Contains('s') || l.Contains('S'))
        {
            ll.Add('S');
        } if (l.Contains('t') || l.Contains('T'))
        {
            ll.Add('T');
        } if (l.Contains('u') || l.Contains('U'))
        {
            ll.Add('U');
        } if (l.Contains('v') || l.Contains('V'))
        {
            ll.Add('V');
        } if (l.Contains('w') || l.Contains('W'))
        {
            ll.Add('W');
        } if (l.Contains('x') || l.Contains('X'))
        {
            ll.Add('X');
        } if (l.Contains('y') || l.Contains('Y'))
        {
            ll.Add('Y');
        } if (l.Contains('z') || l.Contains('Z'))
        {
            ll.Add('Z');
        }
        return ll;
    }
}

public class @base : ViewModelBase
{
}
}