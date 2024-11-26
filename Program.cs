using System;

namespace Lab_4
{
    // Інтерфейс Phone
    public interface Phone
    {
        void MakeCall();
    }

    // Клас, що реалізує інтерфейс Phone
    public class IPhone : Phone
    {
        public void MakeCall()
        {
            Console.WriteLine("Making a call...");
        }
    }

    // Клас VideoCamera, який будемо адаптувати
    public class VideoCamera
    {
        public void StartVideo()
        {
            Console.WriteLine("Starting video...");
        }

        public void StopVideo()
        {
            Console.WriteLine("Stopping video...");
        }
    }

    // Адаптер для використання відеокамери під час виклику
    public class VideoCameraAdapter : IPhone
    {
        private VideoCamera videoCamera;

        public VideoCameraAdapter(VideoCamera camera)
        {
            videoCamera = camera;
        }

        public void MakeCall()
        {
            videoCamera.StartVideo();  // Запуск відео перед викликом
            Console.WriteLine("Making a video call..."); 
            videoCamera.StopVideo();   // Зупинка відео після виклику
        }
    }

    // Приклад використання
    class Program
    {
        static void Main(string[] args)
        {
            Phone Iphone = new IPhone();

            Iphone.MakeCall();  // Звичайний виклик

            Console.WriteLine();

            VideoCamera videoCamera = new VideoCamera();
            Phone videoIPhone = new VideoCameraAdapter(videoCamera);//об'єкт передається в адаптер,який реал інт 

            videoIPhone.MakeCall();  // Відеовиклик з використанням відеокамери
        }
    }
}
