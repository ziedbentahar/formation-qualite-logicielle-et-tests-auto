using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MorseCodeDecoder.Tests
{
    [TestFixture]
    public class MorseCodeDecoderTests
    {  
        public void Decode_should_return_correct_text()
        {
            //Arrange
            Decoder morseCodeDecoder = new Decoder();

            //Act
            var text = morseCodeDecoder.Decode("..-. --- --- ....... -... .- .-.");

            //Assert
            Assert.That(text == "FOO BAR", () => "Morse code not decoded correctly");
        }

        [Test]
        public void Decode_should_throw_not_supported_exception_when_provided_text_is_null_or_empty()
        {
            //Arrange
            Decoder morseCodeDecoder = new Decoder();

            //Act &&  Assert
            Assert.Throws<NotSupportedException>(() => morseCodeDecoder.Decode(null));
        }
    }
}
