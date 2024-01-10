namespace СS_comp
{
    interface IRemovableDisk
    {
        bool HasDisk { get; }
        void Insert();
        void Reject();
    }

    interface IDisk
    {
        string Read();
        void Write(string text);
    }
    interface IPrintInformation
    {
        string GetName();
        void Print(string text);
    }
    class Disk : IDisk
    {

        public string? Memory { get; private set; }
        public int MemSize { get; private set; }

        public Disk(string? memory, int memSize)
        {
            Memory = memory;
            MemSize = memSize;
        }

        public virtual string GetName()
        {
            return "disk";
        }

        public string Read()
        {
            return "Reading...";
        }

        public void Write(string text)
        {
            Console.WriteLine($"{text} - has been writen to {GetName()}.");
        }
    }

    class CD : Disk, IRemovableDisk
    {
        protected bool hasDisk = false;

        public CD(string? memory, int memSize) : base(memory, memSize)
        {
        }

        public bool HasDisk => hasDisk;

        public void Insert()
        {
            if (HasDisk)
            {
                Reject();
                return;
            }
            Console.WriteLine("CD inserted");
            hasDisk = true;
        }

        public void Reject()
        {
            Console.WriteLine("CD insertion rejected");
        }
        public override string GetName()
        {
            return "CD " + base.GetName();
        }
    }

    class Flash : Disk, IRemovableDisk
    {
        protected bool hasDisk = false;

        public Flash(string? memory, int memSize) : base(memory, memSize)
        {
        }
        public bool HasDisk => hasDisk;

        public void Insert()
        {
            if (HasDisk)
            {
                Reject();
                return;
            }
            Console.WriteLine("Flash inserted");
            hasDisk = true;
        }

        public void Reject()
        {
            Console.WriteLine("Flash insertion rejected");
        }
        public override string GetName()
        {
            return "Flash " + base.GetName();
        }
    }

    class DVD : Disk, IRemovableDisk
    {
        protected bool hasDisk = false;

        public DVD(string? memory, int memSize) : base(memory, memSize)
        {
        }
        public bool HasDisk => hasDisk;

        public void Insert()
        {
            if (HasDisk)
            {
                Reject();
                return;
            }
            Console.WriteLine("DVD inserted");
            hasDisk = true;
        }

        public void Reject()
        {
            Console.WriteLine("DVD insertion rejected");
        }
        public override string GetName()
        {
            return "DVD " + base.GetName();
        }
    }

    class HDD : Disk
    {
        public HDD(string? memory, int memSize) : base(memory, memSize)
        {
        }
        public override string GetName()
        {
            return "HDD " + base.GetName();
        }
    }

    class Printer : IPrintInformation
    {
        public string GetName()
        {
            return "Printer";
        }

        public void Print(string text)
        {
            Console.WriteLine($"Printer print: {text}");
        }
    }

    class Monitor : IPrintInformation
    {
        public string GetName()
        {
            return "Monitor";
        }

        public void Print(string text)
        {
            Console.WriteLine($"Monitor print: {text}");
        }
    }

    

    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}