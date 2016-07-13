using System;
using System.Collections.Generic;
using Generic.Framework.Interfaces.GuidIdTree;

namespace Generic.Framework.Helpers.GuidTree
{
    public static class GuidTreeHelper
    {
        public static void UpdateAncestry(this IGuidTreeItem guidTreeItem)
        {
            guidTreeItem.Ancestry = guidTreeItem.GetAncestry();
        }

        public static string GetAncestry(this IGuidTreeItem guidTreeItem)
        {
            var ancestry = new List<IGuidTreeItem>();
            var currentStage = guidTreeItem;

            while (currentStage != null)
            {
                if (ancestry.Contains(currentStage))
                    throw new StackOverflowException("The current tree structure contains a loop");

                ancestry.Add(currentStage);
                currentStage = currentStage.Parent;
            }

            return BuildAcestryString(ancestry);
        }

        private static string BuildAcestryString(List<IGuidTreeItem> ancestry)
        {
            var ancestryString = string.Empty;

            //Start from the end and work backwards
            for (int i = ancestry.Count - 1; i >= 0; i--)
                ancestryString += ancestry[i].Id.ToString();

            return ancestryString;
        }

        public static void UpdateAncestry<T>(this IGuidTreeItemGeneric<T> guidTreeItem, bool usePopulatedParentIfPossible = false)
        {
            guidTreeItem.Ancestry = guidTreeItem.GetAncestry(usePopulatedParentIfPossible);
        }

        public static string GetAncestry<T>(this IGuidTreeItemGeneric<T> guidTreeItem, bool usePopulatedParentIfPossible = false)
        {
            if (usePopulatedParentIfPossible && guidTreeItem.Parent != null && guidTreeItem.Parent.Ancestry != null)
                return guidTreeItem.Parent.Ancestry + guidTreeItem.Id;

            var ancestry = new List<IGuidTreeItemGeneric<T>>();
            var currentStage = guidTreeItem;

            while (currentStage != null)
            {
                if (ancestry.Contains(currentStage))
                    throw new StackOverflowException("The current tree structure contains a loop");

                ancestry.Add(currentStage);
                currentStage = currentStage.Parent;
            }

            return BuildAcestryString(ancestry);
        }
        
        private static string BuildAcestryString<T>(List<IGuidTreeItemGeneric<T>> ancestry)
        {
            var ancestryString = string.Empty;

            //Start from the end and work backwards
            for (int i = ancestry.Count - 1; i >= 0; i--)
                ancestryString += ancestry[i].Id.ToString();

            return ancestryString;
        }

        //public static void SetForCascadingDeletion(this IGuidTreeItem guidTreeItem)
        //{
        //    //Recursive loop detection
        //    if(guidTreeItem.PendingDeletion)
        //        return; //We have been here before

        //    guidTreeItem.PendingDeletion = true;

        //    //Recurse down the tree
        //    foreach (var child in guidTreeItem.Children)
        //    {
        //        child.Parent = null;
        //        child.SetForCascadingDeletion();
        //    }
        //}


        public static void SetParentLinkForChildren(this IGuidTreeItem guidTreeItem)
        {
            if(guidTreeItem.Children == null)
                return;

            foreach (var child in guidTreeItem.Children)
            {
                child.Parent = guidTreeItem;
                child.UpdateAncestry();

                //Recurse
                child.SetParentLinkForChildren();
            }
        }

        public static void SetParentLinkForChildren<T>(this IGuidTreeItemGeneric<T> guidTreeItem) where T : class, IGuidTreeItemGeneric<T>
        {
            if (guidTreeItem.Children == null)
                return;

            foreach (var child in guidTreeItem.Children)
            {
                child.Parent = guidTreeItem;
                child.UpdateAncestry();

                //Recurse
                child.SetParentLinkForChildren();
            }
        }

        public static int GetTreeLevel<T>(this IGuidTreeItemGeneric<T> guidTreeItem)
        {
            return guidTreeItem.Ancestry.Length / Guid.Empty.ToString().Length;
        }
    }
}