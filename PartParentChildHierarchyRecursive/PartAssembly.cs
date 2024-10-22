namespace PartParentChildHierarchyRecursive
{
    public record PartAssembly
    {
        public int PartID { get; set; }
        public int ParentPartID { get; set; }
        public string PartNumber { get; set; }
        public string PartDescription { get; set; }
        public List<PartAssembly> Children { get; set; }

        public PartAssembly()
        {
            PartID = 0;
            ParentPartID = 0;
            PartNumber = string.Empty;
            PartDescription = string.Empty;
            Children = new List<PartAssembly>();
        }
    }
}
