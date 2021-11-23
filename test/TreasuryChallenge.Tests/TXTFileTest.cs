using Xunit;
using TreasuryChallenge.Model;
using TreasuryChallenge.utils;
using TreasuryChallenge.controller;

namespace TreasuryChallenge
{
    public class TXTFileTest
    {
        [Fact]
        public void Generete_Char_ReturnTotalCharEqualThePastValue()
        {
            TemplateFile txtFile = new TXTFile("file-teste", 8);
            string content = txtFile.GenerateContent();

            Assert.Equal(8 , content.Length);
        }

        [Fact]
        public void Valid_OneCharInsideOfString_ReturnTrue()
        {
            string content = "UJHSNKL";
            bool result = TreasuryUtils.FoundChar(content, "U");

            Assert.True(result);
        } 

        [Fact]
        public void Valid_OneCharInsideOfString_ReturnFalse()
        {
            string content = "UJHSNKL";
            bool result = TreasuryUtils.FoundChar(content, "Y");

            Assert.False(result);
        } 

        [Fact]
        public void Generete_Char_ReturnStringLengthIqualOne()
        {
            string resultChar = TreasuryUtils.GetChar();
            
            Assert.Equal(1, resultChar.Length);
        }

        [Fact]
        public void Call_WriteCodeInFile_MustExecuteSuccessfully()
        {
            try
            {
                TemplateFile txtTemplate = new TXTFile("aleatory-file", 7);
                WriteFileController  writeFile = new WriteFileController(2);
                writeFile.WriteCodeInFile(txtTemplate);

                Assert.True(true);
            }
            catch {
                Assert.True(false);
            }
        }
    }
}
