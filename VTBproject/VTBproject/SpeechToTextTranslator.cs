using System.Speech.Recognition;
namespace VTBproject
{
    class SpeechToTextTranslator
    {
       /* SpeechRecognitionEngine recognizer; 
        
        public SpeechToTextTranslator()
        {
            recognizer = new SpeechRecognitionEngine();
        }

        public string StartRecord()
        {
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.LoadGrammar(new DictationGrammar());

            // Обработка события распознавания речи
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

            // Начать асинхронное распознавание речи
            recognizer.RecognizeAsync(RecognizeMode.Multiple);

            // Ожидание нажатия клавиши Enter для завершения программы
            Console.WriteLine("Нажмите Enter для завершения");
            Console.ReadLine();
        }
        static string recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            return e.Result.Text;
        }*/
    }
}
