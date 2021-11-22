using EFCUTY_HFT_2021221.Logic;
using EFCUTY_HFT_2021221.Models;
using EFCUTY_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WorldDb.Test
{
    [TestFixture]
    public class Tester
    {

        CountryLogic cl;

        [SetUp]
        public void Init()
        {
            var mockCarRepository =
                new Mock<ICountryRepository>();

            Country fakeCountry = new Country();
            List<Settlement> fakeSettlements = new();
            List<Citizen> fakeCitizens = new();


            fakeCountry.CountryID = 1;
            fakeCountry.Name = "Hungary";
            var countries = new List<Country>()
                {
                    new Country(){
                        HDI=0.944,
                        Settlements=fakeSettlements,
                        Citizens=fakeCitizens
                        
                    },
                    new Country(){
                        
                    }
                }.AsQueryable();

            mockCarRepository.Setup((t) => t.GetAll())
                .Returns(countries);

            cl = new CountryLogic(
                mockCarRepository.Object);
        }

        [Test]
        public void AVGPriceTest()
        {

            //ACT
            var result = cl.HDI();

            //ASSERT
            Assert.That(result, Is.EqualTo(1500));
        }

        [Test]
        public void AVGHDITest()
        {
            //ACT
            var result = cl.HDI();

            //ASSERT
            var expected = new List
                <KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>
                ("test")
            };
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AVGHDITest()
        {
            //ACT
            var result = cl.HDI();

            //ASSERT
            var expected = new List
                <KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>
                ("test")
            };
            Assert.That(result, Is.EqualTo(expected));
        }


        [Test]
        public void AVGHDITest()
        {
            //ACT
            var result = cl.HDI();

            //ASSERT
            var expected = new List
                <KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>
                ("test")
            };
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
