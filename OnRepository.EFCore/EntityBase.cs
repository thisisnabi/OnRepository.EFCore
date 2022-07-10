namespace OnRepository.EFCore;

public abstract class EntityBase
{
    private int _Id;

    public virtual int Id
    {
        get
        {
            return _Id;
        }
        protected set
        {
            _Id = value;
        }
    }
 
    public override int GetHashCode() 
        => Id.GetHashCode();
    
    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is EntityBase))
        { return false; }

        if (Object.ReferenceEquals(this, obj))
        { return true; }

        if (GetType() != obj.GetType())
        { return false; }

        EntityBase item = (EntityBase)obj;
 
        // this.Id
        return item.Id == Id;
    }

    public static bool operator ==(EntityBase left, EntityBase right)
    {
        if (Equals(left, null))
        {
            return Equals(right, null) ? true : false;
        }

        return left.Equals(right);
    }

    public static bool operator !=(EntityBase left, EntityBase right)
    {
        return !(left == right);
    }
 
}
