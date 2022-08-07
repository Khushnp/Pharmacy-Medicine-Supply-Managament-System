using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.MedicineStockRepository.Models
using System.MedicineStockRepository.Repos;
using Moq;

namespace MedicineStockUnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        private Mock<MedicineStockRepo> _repo;
        public MedicineStockRepo repo;
        List<MedicineStock> medicinestock;
        [SetUp]
        public void Setup()
        {
            _repo = new Mock<IMedicineStockRepo>();

            medicinestock = new List<MedicineStock>
                {
                new MedicineStock{MedicineId = "0001", MedicineName = "Aspirin",ChemicalComposition = "Acetylsalicyclic acid",TargetAilment = "General",DateOfExpiry= "22-10-2021",NumberOfTabletsInStock= 250},
                new MedicineStock {MedicineId = "0002", MedicineName = "Codeine",ChemicalComposition = "serotonin",TargetAilment = "Orthopaedics",DateOfExpiry= "20-8-2021",NumberOfTabletsInStock= 100},
                new MedicineStock {MedicineId = "0003", MedicineName = "Mifepristone",ChemicalComposition = "methotrexate",TargetAilment = "Gynaecology",DateOfExpiry= "1-1-2022",NumberOfTabletsInStock= 300},
                new MedicineStock {MedicineId = "0004", MedicineName = "Combiflam",ChemicalComposition = "Acetaminophen",TargetAilment = "General",DateOfExpiry= "30-9-2021",NumberOfTabletsInStock= 150},
                new MedicineStock {MedicineId = "0004", MedicineName = "Misoprostol",ChemicalComposition = "Adenylate cyclase",TargetAilment = "Gynaecology",DateOfExpiry= "22-10-2021",NumberOfTabletsInStock= 200},
                new MedicineStock {MedicineId = "0005", MedicineName = "Cytotec",ChemicalComposition = "Myo-Inostiol, D-Chiro-Inostiol, L-Methyl Folate",TargetAilment = "Gynaecology ",DateOfExpiry= "15-5-2021",NumberOfTabletsInStock= 200}
                 };
            _repo.Setup(m => m.GetAllMedicines()).Returns(medicinestock);
            repo = _repo.Object;
            _repo.Setup(m => m.GetMedicineStockById("0003")).Returns(medicinestock);
            repobyId = _repo.Object;

        }

        [Test]
        public void MedicineStockInfoTest_PassCase_Repository()
        {
            List<MedicineStock> result = repo.GetAllMedicines();
            Assert.IsNotNull(result);
        }

        [Test]
        public void MedicineStockInfoTest_PassCase_forID_Repository()
        {
            MedicineStock result = repo.GetMedicineStockById("0003");
            Assert.IsNotNull(result);
        }
        [Test]
        public void MedicineStockInfoTest_FailCase_Repository()
        {
            medicinestock = null;
            _repo.Setup(m => m.GetAllMedicines()).Returns(medicinestock);
            repo = _repo.Object;
            List<MedicineStock> result = repo.GetAllMedicines();
            Assert.IsNull(result);
        }


    }
}
