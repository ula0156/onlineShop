namespace onlineShop
{
    // This class derives from PhysicalProduct. In other words we can say that this class
    // is a subclass of PhysicalProduct and that PhysicalProduct is a superclass, or parent
    // class of Backpack.
    class Backpack: PhysicalProduct
    {
        // When we construct a backpack we also need to call the constructor of the superclass.
        // We do that by used the base keyword and providing to it the parameters that it needs.
        // If you hover the mouse over the base word below you will see that it is actually
        // the constructor of the PhysicalProduct class.
        // We can explain this by saying that you cannot have a backpack object unless you
        // first satisfy the requirements of PhysicalProduct.
        public Backpack(double volumeInLiters,
                        string material,
                        string name,
                        double price,
                        string tags,
                        Size size,
                        Manufacturer manufacturer)
            : base(name, price, tags, size, manufacturer)
        {
            
            Volume = volumeInLiters;
            Material = material;
            
        }
        #region Propertie:
        public double Volume { get; set; }
        public string Material { get; set; }
        #endregion;
    }
}
