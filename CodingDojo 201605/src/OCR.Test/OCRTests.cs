using FluentAssertions;
using NUnit.Framework;

namespace OCR.Test
{
    [TestFixture]
    public class OcrTests
    {
        [Test]
        public void GivenSingle1_Return1()
        {
            var one = @"   
  |
  |
";
            var parser = new OcrParser();

            var result = parser.Parse(one);

            result.Should().Be("1");
        }

        [Test]
        public void GivenSingle2_Return2()
        {
            var two = @" _ 
 _|
|_ 
";
            var parser = new OcrParser();

            var result = parser.Parse(two);

            result.Should().Be("2");
        }


        [Test]
        public void GivenSingle3_Return3()
        {
            var three = @" _ 
 _|
 _|
";
            var parser = new OcrParser();

            var result = parser.Parse(three);

            result.Should().Be("3");
        }

        [Test]
        public void GivenNine1_Return111111111()
        {
            var nineOnes =
                @"                           
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |
";
            var parser = new OcrParser();

            var result = parser.Parse(nineOnes);

            result.Should().Be("111111111");
        }

        [Test]
        public void GivenNine5_Return555555555()
        {
            var nineFives =
                @" _  _  _  _  _  _  _  _  _ 
|_ |_ |_ |_ |_ |_ |_ |_ |_ 
 _| _| _| _| _| _| _| _| _|
";
            var parser = new OcrParser();

            var result = parser.Parse(nineFives);

            result.Should().Be("555555555");
        }

        [Test]
        public void GivenNine2_Return222222222()
        {
            var nineTwos =
                @" _  _  _  _  _  _  _  _  _ 
 _| _| _| _| _| _| _| _| _|
|_ |_ |_ |_ |_ |_ |_ |_ |_ 
";
            var parser = new OcrParser();

            var result = parser.Parse(nineTwos);

            result.Should().Be("222222222");
        }


        [Test]
        public void GivenThis_Return222212222()
        {
            var number =
                @" _  _  _  _     _  _  _  _ 
 _| _| _| _|  | _| _| _| _|
|_ |_ |_ |_   ||_ |_ |_ |_ 
";
            var parser = new OcrParser();

            var result = parser.Parse(number);

            result.Should().Be("222212222");
        }

        [Test]
        public void GivenNineNines_Return999999999()
        {
            var nineNines =
                @" _  _  _  _  _  _  _  _  _ 
|_||_||_||_||_||_||_||_||_|
 _| _| _| _| _| _| _| _| _|
";
            var parser = new OcrParser();

            var result = parser.Parse(nineNines);

            result.Should().Be("999999999");
        }

        [Test]
        public void GivenOneToNine_Return123456789()
        {
            var OneToNine =
                @"    _  _     _  _  _  _  _ 
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|
";
            var parser = new OcrParser();

            var result = parser.Parse(OneToNine);

            result.Should().Be("123456789");
        }

        [Test]
        public void Given94357453_ReturnChecksum7()
        {
            var no = @"94357453";
            var generator = new ChecksumGenerator();

            var result = generator.GenerateChecksum(no);

            result.Should().Be(7);
        }

        [Test]
        public void Given99772564_ReturnChecksum6()
        {
            var no = @"99772564";
            var generator = new ChecksumGenerator();

            var result = generator.GenerateChecksum(no);

            result.Should().Be(6);
        }

        [Test]
        public void Given91685876_ReturnChecksum0()
        {
            var no = @"91685876";
            var generator = new ChecksumGenerator();

            var result = generator.GenerateChecksum(no);

            result.Should().Be(0);
        }

        [Test]
        public void Given991781544_ReturnEmptyString()
        {
            var completeOrgNum = @"991781544";
            var orgNumWithouthChecksum = completeOrgNum.Substring(0, completeOrgNum.Length - 1);

            var generator = new ChecksumGenerator();
            var checksum = generator.GenerateChecksum(orgNumWithouthChecksum);
            var result = generator.ValidateChecksum(completeOrgNum, checksum);

            result.Should().Be("");
        }


    }


}