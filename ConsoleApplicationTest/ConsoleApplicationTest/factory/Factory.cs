using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.factory
{
    abstract class SimpleFactory
    {
        public static Product createProduct(EProductType type)
        {
            Product product = null;
            switch (type)
            {
                case EProductType.FEILIAO:
                    {
                        product = new Feiliao();
                        break;
                    }

                case EProductType.FEIXIN:
                    {
                        product = new Feixin();
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
            return product;
        }
    }

    abstract class Factory
    {
        public Product orderProduct(EProductType type, IAbstractFactroy abstractFactroy)
        {
            Product product = createProduct(type);
            product.abstractFactroy = abstractFactroy;
            product.start();
            return product;
        }

        public abstract Product createProduct(EProductType type); // 工厂方法
    }

    class BeijingFactory : Factory
    {
        public override Product createProduct(EProductType type)
        {
            return SimpleFactory.createProduct(type);
        }
    }

    class NanjingFactory : Factory
    {
        public override Product createProduct(EProductType type)
        {
            return SimpleFactory.createProduct(type);
        }
    }
}
