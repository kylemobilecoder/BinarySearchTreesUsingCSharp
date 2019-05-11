/*Katrina Coloso, 2005-67067, Binary Search Tree Implementation using Linked Lists 
*/using System;
namespace ConsoleApp2 {  
class Program
{
    static void Main(string[] args)
    {

            int val, ch  = 0;
            BinaryTree mylist = new BinaryTree();
        
            while (true)
            {
                Console.Clear();

                Console.WriteLine("[1] Insert Node to Binary Search Tree");
                Console.WriteLine("[2] Delete Node from Binary Search Tree");
                Console.WriteLine("[3] Minimum value in BST is: ");
                Console.WriteLine("[4] Maximum value in BST is: ");
                Console.WriteLine("[5] Successor");
                Console.WriteLine("[6] Predecessor");
                Console.WriteLine("[7] Search");
                Console.WriteLine("[8] Print BST");
                Console.WriteLine("[9] Exit Console");

                Console.Write("\nEnter your choice:");
                ch = int.Parse(Console.ReadLine());

               switch (ch)
                {
                    case 1:
                        Console.Write("Enter a value: ");
                        val = int.Parse(Console.ReadLine());
                        mylist.Insert(val);
                        break;

                    case 2:
                        Console.Write("Specify value to be deleted: ");
                        val = int.Parse(Console.ReadLine());
                        mylist.Remove(val);
                        break;

                    case 3:
                       Console.Write("Smallest value in BST is: ");
                       Console.WriteLine(mylist.Smallest());
                       break;

                    case 4:
                        Console.Write("Largest value in BST is: ");
                        Console.WriteLine(mylist.Largest());
                        break;

                    case 5:
                        Console.Write("Enter a value: ");
                        val = int.Parse(Console.ReadLine());
                        mylist.PublicTreeSuccessor(val);
                        break; 

                    case 6:                       
                        Console.Write("Enter a value: ");
                        val = int.Parse(Console.ReadLine());                     
                        mylist.PublicTreePredecessor(val);
                        break;

                    case 7:
                        Console.Write("Find value: ");
                        val = int.Parse(Console.ReadLine());
                        var tree = mylist.Find(val);
                        break;

                    case 8:
                        Console.WriteLine();
                        mylist.InOrderTraversal();
                        break;

                    case 9:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();

            }
                 
       }   
    }
    } 