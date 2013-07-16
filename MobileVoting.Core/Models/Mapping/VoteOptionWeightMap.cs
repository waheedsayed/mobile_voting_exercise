using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MobileVoting.Core.Models.Mapping
{
    public class VoteOptionWeightMap : EntityTypeConfiguration<VoteOptionWeight>
    {
        public VoteOptionWeightMap()
        {
            // Primary Key
            HasKey(t => t.OptionId);

            // Properties
            Property(t => t.OptionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            ToTable("VoteOptionWeight");
            Property(t => t.OptionId).HasColumnName("VoteOptionId");
            Property(t => t.Weight).HasColumnName("Weight");
        }
    }
}