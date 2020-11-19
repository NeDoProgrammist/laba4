using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    public class Transport 
    {
        public static Random rnd = new Random();
        public int wheels = 0;
        public virtual String GetInfo()
        {
            var str = String.Format("\nКоличество колёс: {0}", this.wheels);
            return str;
        }
    }

    // Самолёт
    public enum PlaneEngineType { газотурбинный, турбовинтовой, ракетный };
    public class Plane : Transport
    {
        public PlaneEngineType engine = PlaneEngineType.газотурбинный;
        public int maxFlight = 0; // максимальная высота полёта
        public override String GetInfo()
        {
            var str = "Самолёт";
            str += base.GetInfo();
            str += String.Format("\nТип двигателя:\n{0}", this.engine);
            str += String.Format("\nМакс. высота:\n{0}", this.maxFlight);
            return str;
        }
        public static Plane Generate()
        {
            return new Plane
            {
                wheels = 3 + rnd.Next() % 5,
                engine = (PlaneEngineType)rnd.Next(3),
                maxFlight = rnd.Next() % 100 *1000
            };
        }
    }

    // Велосипед
    public enum BicycleType { горный, городской, детский };
    public class Bicycle : Transport
    {
        public BicycleType type = BicycleType.горный;
        public int rad = 0; // радиус колёс
        public override String GetInfo()
        {
            var str = "Велосипед";
            str += base.GetInfo(); // и тут так же
            str += String.Format("\nТип:\n{0}", this.type);
            str += String.Format("\nРадиус колёс:\n{0}", this.rad);
            return str;
        }
        public static Bicycle Generate()
        {
            return new Bicycle
            {
                wheels = 2 + rnd.Next() % 2,
                type = (BicycleType)rnd.Next(3),
                rad = rnd.Next() % 100
            };
        }
    }

    // Автомобиль
    public enum CarType { автобус, грузовик, внедорожник, легковая };
    public class Car : Transport
    {
        public CarType type = CarType.автобус;
        public int vEngine = 0; // объём двигателя
        public int door = 0; // количество дверей
        public override String GetInfo()
        {
            var str = "Автомобиль";
            str += base.GetInfo(); // и тут так же
            str += String.Format("\nТип:\n{0}", this.type);
            str += String.Format("\nОбъём двигателя:\n{0}", this.vEngine);
            str += String.Format("\nКоличество дверей:\n{0}", this.door);
            return str;
        }
        public static Car Generate()
        {
            return new Car
            {
                wheels = 4,
                type = (CarType)rnd.Next(4),
                vEngine = 100 + rnd.Next() % 100,
                door = 1 + rnd.Next() % 5
            };
        }
    }
}
