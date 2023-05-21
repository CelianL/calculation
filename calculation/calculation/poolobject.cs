using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculation
{
    public class CalculationObject
    {
        // Propriétés de l'objet de calcul
        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public int Result { get; set; }

        // Méthode de calcul
        public void Calculate(ICalculationStrategy strategy)
        {
            Result = strategy.Calculate(Operand1, Operand2);
        }
    }

    public class CalculationObjectPool
    {
        private readonly Queue<CalculationObject> objectPool;

        public CalculationObjectPool(int poolSize)
        {
            objectPool = new Queue<CalculationObject>();
            InitializeObjectPool(poolSize);
        }

        private void InitializeObjectPool(int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
            {
                objectPool.Enqueue(new CalculationObject());
            }
        }

        public CalculationObject AcquireObject()
        {
            if (objectPool.Count > 0)
            {
                return objectPool.Dequeue();
            }

            throw new InvalidOperationException("No objects available in the pool.");
        }

        public void ReleaseObject(CalculationObject calculationObject)
        {
            calculationObject.Operand1 = 0;
            calculationObject.Operand2 = 0;
            calculationObject.Result = 0;
            objectPool.Enqueue(calculationObject);
        }
    }
}
