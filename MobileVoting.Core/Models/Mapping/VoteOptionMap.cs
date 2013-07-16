using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MobileVoting.Core.Models.Mapping
{
    public class VoteOptionMap : EntityTypeConfiguration<VoteOption>
    {
        public VoteOptionMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Table & Column Mappings
            ToTable("VoteOptions");
            Property(t => t.Id).HasColumnName("VoteOptionId");
            Property(t => t.VoteId).HasColumnName("VoteId");
            Property(t => t.OptionId).HasColumnName("OptionId");

            // Relationships
            HasRequired(t => t.Vote)
                .WithMany(t => t.VoteOptions)
                .HasForeignKey(d => d.VoteId)
                .WillCascadeOnDelete(false);

            HasRequired(t => t.QuestionOption)
                .WithMany(t => t.VoteOptions)
                .HasForeignKey(d => d.OptionId)
                .WillCascadeOnDelete(false);

            HasOptional(t => t.VoteOptionWeight)
                .WithRequired(t => t.VoteOption)
                .WillCascadeOnDelete(false);
        }
    }
}