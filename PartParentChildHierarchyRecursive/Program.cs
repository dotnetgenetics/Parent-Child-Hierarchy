namespace PartParentChildHierarchyRecursive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BuildPartAssemblyHierarchy assemblyHierarchy = new BuildPartAssemblyHierarchy();
            assemblyHierarchy.ShowParentChildAssemblies();
            Console.WriteLine("\n\n\nDONE...!");
        }
    }
}
