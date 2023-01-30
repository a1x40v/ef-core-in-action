namespace EfInAction.Examples.Chapter7.OwnedTypes
{
    public static class OwnedTypes
    {
        public static void Main()
        {
            HeldInTheSameTableExample();
        }

        public static void HeldInTheSameTableExample()
        {
            RemoveData();
            SeedData();

            using (var context = new Chapter7DbContext())
            {
                var order = context.OrderInfos.First(); // (*)

                Console.WriteLine($"Billing Adress street: {order.BillingAddress.NumberAndStreet}");
                Console.WriteLine($"Delivery address is null? {order.DeliveryAddress == null}"); // (**)
            }
        }

        public static void SeedData()
        {
            using (var context = new Chapter7DbContext())
            {
                if (!context.OrderInfos.Any())
                {
                    var order = new OrderInfo
                    {
                        OrderNumber = "111",
                        BillingAddress = new Address { NumberAndStreet = "11 First street", City = "First City" },
                        DeliveryAddress = new Address { }
                    };
                    context.Add(order);
                    context.SaveChanges();
                }
            }
        }

        public static void RemoveData()
        {
            using (var context = new Chapter7DbContext())
            {
                var orders = context.OrderInfos.ToList();

                foreach (var order in orders)
                {
                    context.Remove(order);
                }

                context.SaveChanges();
            }
        }
    }
}

/*
    Owned Types позволяют определить класс, хранящий общие данные, которые можно использовать для нескольких entity.
    
    Не требуется (*) загружать (Include).
    Все колонки в Owned Type по-умолчанию являются nullable.

    Если все свойства для OwnedType являются null (**), то вместо экземпляра класса будет установлен null
*/