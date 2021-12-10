namespace Mandatum.Convertors
{
    public interface IConverter<T1Class, T2Class>
    {
        public T1Class Convert(T2Class source);
        public T2Class Convert(T1Class source);
    }
}