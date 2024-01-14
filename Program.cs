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


        public Disk() { }
        public Disk(string memory, int memSize)
        {
            Memory = memory;
            MemSize = memSize;
        }

        public virtual string GetName()
        {
            return "disk";
        }

        public virtual string Read()
        {
            return Memory + " reading..." ;
        }

        public virtual void Write(string text)
        {
            Console.WriteLine($"{text} - has been writen to {GetName()}.");
        }
    }

    class CD : Disk, IRemovableDisk
    {
        protected bool hasDisk = false;

        public CD(int memSize) : base("CD", memSize)
        {
        }

        public bool HasDisk => hasDisk;

        public void Insert()
        {
            Console.WriteLine($"{Memory} inserted");
        }

        public void Reject()
        {
            Console.WriteLine($"{Memory} insertion rejected");
        }
        public override string GetName()
        {
            return $"{Memory} " + base.GetName();
        }
    }

    class Flash : Disk, IRemovableDisk
    {
        protected bool hasDisk = false;

        public Flash(int memSize) : base("Flash", memSize)
        {
        }
        public bool HasDisk => hasDisk;

        public void Insert()
        {
            Console.WriteLine($"{Memory} inserted");
        }

        public void Reject()
        {
            Console.WriteLine($"{Memory} insertion rejected");
        }
        public override string GetName()
        {
            return $"{Memory} " + base.GetName();
        }
    }

    class DVD : Disk, IRemovableDisk
    {
        protected bool hasDisk = false;

        public DVD( int memSize) : base("DVD", memSize)
        {
        }
        public bool HasDisk => hasDisk;

        public void Insert()
        {
            Console.WriteLine($"{Memory} inserted");
        }

        public void Reject()
        {
            Console.WriteLine($"{Memory} insertion rejected");
        }
        public override string GetName()
        {
            return $"{Memory} " + base.GetName();
        }
    }

    class HDD : Disk
    {
        public HDD(int memSize) : base("HDD", memSize)
        {
        }
        public override string GetName()
        {
            return $"{Memory} " + base.GetName();
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

    class Comp
    {
        public int CountDisk { get; private set; }
        public int CountPrintDevice { get; private set; }

        public Disk[] disks { get; private set; }
        public IPrintInformation[] printDevice { get; set; }

        public Comp(int d, int pd) {
            CountDisk = d;
            CountPrintDevice = pd;
            disks = new Disk[d];
            printDevice = new IPrintInformation[pd];
        }
        public void AddDevice(int index, IPrintInformation si) {
            if (index >= 0 && index < printDevice.Length) {
                printDevice[index] = si;
            }
            else { throw new IndexOutOfRangeException(); }
        }
        public void AddDisk(int index, Disk d)
        {
            if (index >= 0 && index < disks.Length)
            {
                disks[index] = d;
            }
            else { throw new IndexOutOfRangeException(); }
        }

        public bool checkDisk(string device)
        {
            return Array.Exists(disks, x => x.Memory == device);
        }
        public void InsertReject(string device, bool b)
        {
            if (checkDisk(device))
            {
                Disk[] set = Array.FindAll(disks, x => x.Memory == device);

                foreach (Disk disk in set)
                {
                    if (disk is IRemovableDisk)
                    {
                        if (b)
                        {
                            (disk as IRemovableDisk).Insert();
                        }
                        else (disk as IRemovableDisk).Reject();
                    }
                    else Console.WriteLine(disk.GetName() + " are not removable");
                }
            } else Console.WriteLine(device + " not found");
        }

        public void PrintInfo(string text, string device)
        {
            var dev = Array.Find(printDevice, x => x.GetName() == device);
            if (dev == null)
            {
                Console.WriteLine(device + " not found");
                return;
            }
            dev.Print(text);
        }

        public void ReadInfo(string device)
        {
            var dev = Array.Find(disks, x => x.Memory == device);
            if (dev == null)
            {
                Console.WriteLine(device + " not found");
                return;
            }
            Console.WriteLine(dev.Read());
        }

        public void ShowDick() 
        {
            Console.WriteLine("Disks: \n");
            foreach (var item in disks)
            {
                Console.WriteLine(item.GetName());
                Console.WriteLine();
            }
        }
        public void ShowPrintDevice()
        {
            Console.WriteLine("Print devices: \n");
            foreach (var item in printDevice)
            {
                Console.WriteLine(item.GetName());
                Console.WriteLine();
            }
        }
        public void WriteInfo(string text, string device)
        {
            var dev = Array.Find(disks, x => x.Memory == device);
            if (dev == null)
            {
                Console.WriteLine(device + " not found");
                return;
            }
            dev.Write(text);
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            Comp comp = new Comp(5,2);
            CD cd = new CD(50);
            Flash flash = new Flash(300);
            HDD hDD = new HDD(6000);
            DVD dVD = new DVD(60);
            comp.AddDevice(0, new Printer());
            comp.AddDevice(1, new Monitor());
            comp.AddDisk(0, cd);
            comp.AddDisk(1, flash);
            comp.AddDisk(2, new Flash(450));
            comp.AddDisk(3, hDD);
            comp.AddDisk(4, dVD);
            comp.ShowDick();
            comp.ShowPrintDevice();

            Console.WriteLine(comp.checkDisk("HDD"));
            comp.InsertReject("HDD", true);
            comp.InsertReject("CD", true);
            comp.PrintInfo("Hello world","Monitor");
            comp.PrintInfo("Hello world", "nitor");
            comp.ReadInfo("HDD");
            comp.ReadInfo("DVD");
            comp.WriteInfo("Some sample info...", "HDD");
            comp.WriteInfo("Some sample info...", "Flash");
        }
    }
}