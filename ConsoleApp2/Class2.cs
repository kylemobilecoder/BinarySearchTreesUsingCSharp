using System;
/*Binary Tree Class
Added a Binary Search Tree class 
A Binary Search Tree is a data structure where the left node is less than parent and right node is greater than its parent
*/
namespace ConsoleApp2
{
    public class BinaryTree
    {
        private TreeNode root;
        public TreeNode Root
        {
            get { return root; }
        }

        public TreeNode Find(int data)
        {
            //if the root is not null then we call the find method on the root
            if (root != null)
            {
                // call node method Find
                return root.Find(data);
            }
            else
            {//the root is null so we return null,  
                Console.WriteLine("Value is not in BST.");
                return null;
            }
        }

        public TreeNode FindRecursive(int data)
        {
            //if the root is not null then we call the recursive find method on the root
            if (root != null)
            {
                //call Node Method FindRecursive
                return root.FindRecursive(data);
            }
            else
            {//the root is null so we return null, nothing to find
                return null;
            }

        }

        public void Insert(int data)
        {
            
            if (root != null) //if the root is not null then we call the Insert method on the root node
            {
                root.Insert(data);
            }
            else //if the root is null then we set the root to be a new node based on the data or value passed in
            {
                root = new TreeNode(data);
            }
        }
        public void Remove(int data)
        {         
            TreeNode current = root;   //Set the current and parent node to root, so when we delete we can delete using the parents reference
            TreeNode parent = root;
            bool isLeftChild = false;//keeps track of which child of the parent should be deleted

           
            if (current == null)  //empty tree then we return null
            {//nothing to be removed, end method
                return;
            }
            //Find the Node
            //loop through until node is not found or if we found the node with matching data
            while (current != null && current.Data != data)
            {              
                parent = current;  //set current node to be new parent reference, then we look at its children

                //if the data we are looking for is less than the current node then we look at its left child
                if (data < current.Data)
                {
                    current = current.LeftNode;
                    isLeftChild = true;//Set the variable to determine which child we are looking at
                }
                else //Else we look at its right child
                {
                    current = current.RightNode;
                    isLeftChild = false;//Set the variable to determine which child we are looking at
                }
            }
         
            if (current == null) //if the node is not found nothing to delete then return 
            {
                return;
            }
            //When we found a Leaf node which does not have a Left Node and Right Node
            if (current.RightNode == null && current.LeftNode == null)
            {             
                if (current == root)  //The root doesn't have parent to check what child it is,so just set to null
                {
                    root = null;
                }
                else
                {                  
                    if (isLeftChild) //When not the root node
                    //see which child of the parent should be deleted
                    {
                       
                        parent.LeftNode = null;  //remove reference to left child node
                    }
                    else //remove reference to right child node
                    {   
                        parent.RightNode = null;
                    }
                }
            }
            else if (current.RightNode == null) //current only has left child, so we set the parents node child to be this nodes left child
            {
               
                if (current == root)  //If the current node is the root then we just set root to Left child node
                {
                    root = current.LeftNode;
                }
                else
                {
                    //check which child of the parent should be deleted
                    if (isLeftChild)//check if this is the right child or left child
                    {
                        //current is left child so we set the left node of the parent to the current nodes left child
                        parent.LeftNode = current.LeftNode;
                    }
                    else
                    {   //current is right child so we set the right node of the parent to the current nodes left child
                        parent.RightNode = current.LeftNode;
                    }
                }
            }
            else if (current.LeftNode == null) //current only has right child, so we set the parents node child to be this nodes right child
            {               
                if (current == root) //If the current node is the root then we just set root to Right child node
                {
                    root = current.RightNode;
                }
                else
                {
                    //see which child of the parent should be deleted
                    if (isLeftChild)
                    {   //current is left child so we set the left node of the parent to the current nodes right child
                        parent.LeftNode = current.RightNode;
                    }
                    else
                    {   //current is right child so we set the right node of the parent to the current nodes right child
                        parent.RightNode = current.RightNode;
                    }
                }
            }
            else//Current Node has both a left and a right child
            {
                //When there are both child nodes go to the right node and then find the leaf node of the left child as this will be the least number
                //that is greater than the current node. It may have right child, so the right child would become..left child of the parent of this leaf --- the successer node

                //Find the successor node which is the least greater node
                TreeNode successor = GetSuccessor(current);
                //if the current node is the root node then the new root is the successor node
                if (current == root)
                {
                    root = successor;
                }
                else if (isLeftChild) //if this is the left child set the parents left child node as the successor node
                {
                    parent.LeftNode = successor;
                }
                else
                {
                    parent.RightNode = successor; //if this is the right child set the parents right child node as the successor node
                }

            }

        }
 
        private TreeNode GetSuccessor(TreeNode node)
        {
            TreeNode parentOfSuccessor = node;
            TreeNode successor = node;
            TreeNode current = node.RightNode;

            //starting at the right child we go down every left child node
            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.LeftNode;// go to next left node
            }
         
            if (successor != node.RightNode)    //if the succesor is not just the right node then
            {
                //set the Left node on the parent node of the succesor node to the right child node of the successor in case it has one
                parentOfSuccessor.LeftNode = successor.RightNode;
                //attach the right child node of the node being deleted to the successors right node
                successor.RightNode = node.RightNode;
            }
            //attach the left child node of the node being deleted to the successors leftnode node
            successor.LeftNode = node.LeftNode;

            return successor;
        }

        //O(Log n) Mark Node as deleted
        public void SoftDelete(int data)
        {
            //find node then set property isdeleted to true
            TreeNode toDelete = Find(data);
            if (toDelete != null)
            {
                toDelete.Delete();
            }
        }

        //find the smallest value in the tree
        public Nullable<int> Smallest()
        {
          
            if (root != null)   //if we have a root node then we can search for the smallest node
            {
                return root.SmallestValue();
            }
            else
            {//else we return null
                return null;
            }
        }

        //find largest value in the tree
        public Nullable<int> Largest()
        {
           
            if (root != null)  //if we have a root node then we can search for the largest node
            {
                return root.LargestValue();
            }
            else
            {//otherwise we return null
                return null;
            }
        }

        //Tree Traversal -- Inorder Traversal
        //In order - goes left to right basically find the left leaf node then its parent then see if the right node has a left node then recursivly go up the tree
        // basically keep going left then recursive to parent then right--values will be printed in ascending order

        public void InOrderTraversal()
        {
            if (root != null)
                root.InOrderTraversal();
        }

        public TreeNode TreeSuccessor(TreeNode current, int value) //Inorder Successor in BST
        {
            TreeNode successor = null; //create successor var
            if (current == null) //if current node is null then tree is empty
            {
                Console.WriteLine("Empty Tree!");
            }
            else if (current.RightNode == null && current.LeftNode == null) //if left and right subtrees are empty, tree has no child
            {
                Console.WriteLine("Tree has no children.");
            }
            else
            {
                while (current.Data != value) //keep looping until the value is found
                {
                    if (current.Data > value) //if value is less than the current node, then successor is in the left subtree
                    {
                        successor = current;
                        current = current.LeftNode;
                    }
                    else
                    {
                        current = current.RightNode; //else go to right subtree
                    }
                }
                if (current.RightNode != null) //if right subtree is not null, look for the minimum value of the right subtree
                {
                    successor = current.RightNode;
                    FindMinimum(successor);
                }
                Console.WriteLine("The Successor is {0}", successor.Data);
                return successor;
            }
            return null;
        }

        public TreeNode FindMinimum(TreeNode successor)
        {
            TreeNode current = successor;

            while (current.LeftNode != null)
            {
                return current = current.LeftNode;
            }
            return current;
        }

        public TreeNode FindMaximum(TreeNode predecessor)
        {
            TreeNode current = predecessor;
            while (current.RightNode != null)
            {
                current = current.RightNode;
            }
            return current;
        }


        public TreeNode TreePredecessor(TreeNode current, int value)
        {
            TreeNode predecessor = null; //create predecessor var
            if (current == null) //if current node is null then tree is empty
            {
                Console.WriteLine("Empty BST.");
            }
            else if (current.RightNode == null && current.LeftNode == null) // if left and right subtrees are empty, tree has no child
            {
                Console.WriteLine("No children node found.");
            }
            else
            {
                while (current.Data != value) //loop until value is found
                {
                    if (current.Data < value) //if value is greater than current node, go to right subtree
                    {
                        predecessor = current;
                        current = current.RightNode;
                    }
                    else
                    {
                        current = current.LeftNode; //else go to left subtree
                    }
                }
                if (current.LeftNode != null) //if left subtree is not null, look for maximum value of left subtree
                {
                    predecessor = current.LeftNode;
                    FindMaximum(predecessor);
                }
                Console.WriteLine("The Predecessor is {0}.", predecessor.Data);
                return predecessor;
            }
            return null;
        }


        public void PublicTreePredecessor(int value) 
        {
            try
            {
                TreePredecessor(root, value);
            }
            catch
            {
                Console.WriteLine("No Predecessor found.");
            }
        }

        public void PublicTreeSuccessor(int value)  
        {
            try
            {
                TreeSuccessor(root, value);
            }
           catch
            {
                Console.WriteLine("No Successor found.");
            }
        }

    }
}