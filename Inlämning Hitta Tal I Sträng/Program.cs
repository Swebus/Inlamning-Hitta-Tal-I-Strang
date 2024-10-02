//Inser att det kunnat göras smidigare med array, men det har vi inte gått igenom ännu så jag körde utan.
using System.Numerics;

BigInteger resultat = 0;
string defaultstring = "29535123p48723487597645723645";
string line;
int u = 0;
Console.WriteLine("Press '1' for default string and '2' to make a custom one!");



string read = Console.ReadLine();
int readint;
bool readparse = int.TryParse(read, out readint);
if (readint == 1)
{
    line = defaultstring;
}
else if (readint == 2)
{
    Console.Write("\n Enter your string here: ");
    string inputline = Console.ReadLine();
    line = inputline;
}
else
{
    line = defaultstring;
    Console.WriteLine("You pressed something else! >:( \n You get the default string!");
}



for (int i = 0; i < 10; i++)               // i är det den letar efter i strängen
{
    u = 0;                                 // u gör att den kan hitta fler än vara första och andra i
    string search = i.ToString();
    while (true)
    {
    int firstindex = line.IndexOf(search, u);        // hittar första 'i' i strängen
    int secondindex = line.IndexOf(search, firstindex + 1);         // hittar andra 'i' i strängen

        if ((firstindex >= 0) && (secondindex >= 0))
        {
            string sub1 = line.Substring(0, firstindex);            // skapar en substring före första i
            string sub2 = line.Substring(firstindex, secondindex - firstindex + 1); // skapar en substring mellan första och andra i
            string sub3 = line.Substring(secondindex + 1);      //skapar en substring efter andra i
            BigInteger sub;
            bool tryparse = BigInteger.TryParse(sub2, out sub);   //försöker omvandla substring mellan i'n till en int

            if (tryparse)        //Om det funkar finns det ignen bokstav i substringen
            {
                Console.Write(sub1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(sub2);
                Console.ResetColor();
                Console.WriteLine(sub3);
                u = secondindex;
                resultat += sub;
            }
            else                //Om det inte funkar fortsätter vi till nästa i
            {
                u++;
            }
        }
        else
        {
            break;
        }   
    }
}
Console.Write("\n The sum of all coloured numbers is: ");
Console.ForegroundColor = ConsoleColor.Red;
Console.BackgroundColor = ConsoleColor.White;
Console.Write("{0}", resultat);
Console.ResetColor();

