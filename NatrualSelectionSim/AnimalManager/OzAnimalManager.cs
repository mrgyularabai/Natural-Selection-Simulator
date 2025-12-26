using System;
using Ozeki;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Diagnostics;

namespace NatrualSelectionSim
{
    public partial class OzAnimalManager
    {
        List<OzAnimal> Animals;
        private List<OzPlant> Plants;
        Random _random;
        float[] defualtTraits;
        public List<OzAnimal> ToBePingedOn;
        public List<OzAnimal> ToBePingedOff;
        public void Start(ref Canvas _canvas, List<OzPlant> plants)
        {
            canvas = _canvas;
            Plants = new List<OzPlant>();
            ToBePingedOn = new List<OzAnimal>();
            ToBePingedOff = new List<OzAnimal>();
            _random = new Random();
            Animals = new List<OzAnimal>();
            Plants = plants;
            defualtTraits = new float[4]{2,15,0.4f, 100 };
            Add(new OzTraits(defualtTraits,0.05f));
        }

        public void Destroy(OzAnimal animal)
        {
            lock (Animals)
            {
                lock (ToBePingedOff)
                {
                    ToBePingedOff.Add(animal);
                    Animals.Remove(animal);
                }
            }
        }
        public void HandleTick()
        {
            lock (Animals)
            {
                for (int x = 0; x < Animals.Count; x++)
                {
                    Animals[x].HandleTick();
                }
            }
        }
        public void HandleDay()
        {
            lock (Animals)
            {
                var original = Animals.Count;
                for (int x = 0; x < original; x++)
                {
                    if (x >= Animals.Count) continue;
                    Animals[x].EndDay();
                }
            }
        }
        /*
        public List<OzAnimal> GetSurroundings(OzAnimal animal)
        {
            OzAnimal[] res = new OzAnimal[Animals.Count];
            Animals.CopyTo(res);
            List<OzAnimal> reslist = res.ToList();
            reslist.Remove(animal);
            List<OzAnimal> result = new List<OzAnimal>();
            GetSurroundingAnimals(animal, reslist, ref result);
            return result;
        }

        public void GetSurroundingAnimals(OzAnimal animal, List<OzAnimal> reslist, ref List<OzAnimal> result)
        {
            for (int x = 0; x < reslist.Count; x++)
            {
                var visible = reslist[x].Position.GetDist(animal.Position) < animal.Traits.Sense.Strength;
                var small = animal.Traits.Size.Strength * 0.7 >= reslist[x].Traits.Size.Strength;
                if (visible && small)
                {
                    result.Add(reslist[x]);
                }
            }
        }
        */
        public List<OzPlant> GetSurroundings(OzAnimal animal)
        {
            var result = new List<OzPlant>();
            for (int x = 0; x < Plants.Count; x++)
            {
                var visible = Plants[x]._pos.GetDist(animal.Position) < animal.Traits.Sense.Strength;
                if (visible)
                {
                    result.Add(Plants[x]);
                }
            }
            return result;
        }

        public void Add(OzTraits traits)
        {
            var pos = new OzPoint2D(_random.Next(50, (int)(canvas.ActualWidth - traits.Size.Strength)), _random.Next(50, (int)(canvas.ActualHeight - traits.Size.Strength)));
            var animal = new OzAnimal(pos, GetSurroundings, Destroy, Add, traits);
            lock (ToBePingedOn)
            {
                lock (Animals)
                {
                    ToBePingedOn.Add(animal);
                    Animals.Add(animal);
                }
            }
        }
        public void Add(OzAnimal child)
        {
            lock(ToBePingedOn)
            {
                lock (Animals)
                {
                    ToBePingedOn.Add(child);
                    Animals.Add(child);
                }
            }
        }
    }
}
