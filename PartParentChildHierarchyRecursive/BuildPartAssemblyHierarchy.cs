namespace PartParentChildHierarchyRecursive
{
    public class BuildPartAssemblyHierarchy
    {
        private List<PartAssembly> Assemblies;
        private List<PartAssembly> OrderedAssemblies;
        private List<PartAssembly> TempAssemblies;

        public BuildPartAssemblyHierarchy()
        {
            OrderedAssemblies = new List<PartAssembly>();
            TempAssemblies = new List<PartAssembly>();

            Assemblies = new List<PartAssembly>()
            {
                new PartAssembly(){ PartID = 1001, PartNumber = "T-B14721", PartDescription="APRON ASSEMBLY", ParentPartID = 0 },
                new PartAssembly(){ PartID = 1006, PartNumber = "T-H03795", PartDescription="ROLLER ASSEMBLY A1", ParentPartID = 1001 },
                new PartAssembly(){ PartID = 1015, PartNumber = "T-F01858", PartDescription="ROLLER ASSEMBLY A2", ParentPartID = 1006 },
                new PartAssembly(){ PartID = 1032, PartNumber = "T-H03860", PartDescription="HYDRAULIC HOSE ASSEMBLY", ParentPartID = 0 },
                new PartAssembly(){ PartID = 1023, PartNumber = "T-B05812", PartDescription="LIFT ACCUMULATOR ASSEMBLY", ParentPartID = 1006 },
                new PartAssembly(){ PartID = 1009, PartNumber = "T-M06525", PartDescription="RETURN FILTER ASSEMBLY", ParentPartID = 1032 },
                new PartAssembly(){ PartID = 1074, PartNumber = "T-F01750", PartDescription="ARMREST CONTROLS ASSEMBLY", ParentPartID = 1009 },
                new PartAssembly(){ PartID = 1333, PartNumber = "T-H01321", PartDescription="OPERATOR CAB ASSEMBLY", ParentPartID = 1001 },
                new PartAssembly(){ PartID = 1211, PartNumber = "T-A15583", PartDescription="CAB DOOR ASSEMBLY", ParentPartID = 1074 },
                new PartAssembly(){ PartID = 1020, PartNumber = "T-M16612", PartDescription="FLOOR MAT ASSEMBLY", ParentPartID = 1445 },
                new PartAssembly(){ PartID = 1445, PartNumber = "T-H01168", PartDescription="BOLT CLAMP ASSEMBLY", ParentPartID = 0 },
                new PartAssembly(){ PartID = 1449, PartNumber = "T-C04287", PartDescription="COVER ASSEMBLY", ParentPartID = 1445 },
                new PartAssembly(){ PartID = 1669, PartNumber = "T-H02194", PartDescription="CONNECTOR ASSEMBLY", ParentPartID = 1449 },
            };
        }

        public void ShowParentChildAssemblies()
        {
            TempAssemblies = GetSubAssembliesOfParent(Assemblies, 0);
            AddToOrderedAssemblies(TempAssemblies);

            foreach (var item in OrderedAssemblies)
            {
                Console.WriteLine($"Part ID: {item.PartID}\t\t" +
                                  $"Parent ID: {item.ParentPartID}\t\t" +
                                  $"Part Number: {item.PartNumber}\t\t" +
                                  $"Description: {item.PartDescription}");
            }
        }

        private List<PartAssembly> GetSubAssembliesOfParent(List<PartAssembly> assemblies, int parentID)
        {
            return assemblies
                      .Where(x => x.ParentPartID == parentID)
                      .Select(x => new PartAssembly()
                      {
                          PartID = x.PartID,
                          ParentPartID = x.ParentPartID,
                          PartNumber = x.PartNumber,
                          PartDescription = x.PartDescription,
                          Children = GetSubAssembliesOfParent(assemblies, x.PartID)
                      }).ToList();
        }

        private void AddToOrderedAssemblies(List<PartAssembly> Assemblies)
        {
            foreach (PartAssembly item in Assemblies)
            {
                //add the currentItem to ordered assemblies
                OrderedAssemblies.Add(new PartAssembly()
                {
                    PartID = item.PartID,
                    ParentPartID = item.ParentPartID,
                    PartDescription = item.PartDescription,
                    PartNumber = item.PartNumber
                });

                AddToOrderedAssemblies(item.Children);
            }
        }
    }
}
