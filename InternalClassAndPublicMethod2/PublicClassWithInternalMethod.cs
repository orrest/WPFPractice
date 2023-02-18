namespace InternalClassAndPublicMethod2
{
    public class PublicClassWithInternalMethod
    {
        internal void CanIBeAccessedFromOtherProject()
        {
            Console.WriteLine("No, I Can't!");
        }
    }
}
