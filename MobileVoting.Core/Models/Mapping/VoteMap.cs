using System.Data.Entity.ModelConfiguration;

namespace MobileVoting.Core.Models.Mapping
{
    public class VoteMap : EntityTypeConfiguration<Vote>
    {
        public VoteMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Table & Column Mappings
            ToTable("Votes");
            Property(t => t.Id).HasColumnName("VoteId");
            Property(t => t.QuestionId).HasColumnName("QuestionId");
            Property(t => t.DateCreated).HasColumnName("DateCreated");
            Property(t => t.LastModified).HasColumnName("LastModified");

            // Relationships
            HasRequired(t => t.Question)
                .WithMany(t => t.Votes)
                .HasForeignKey(d => d.QuestionId)
                .WillCascadeOnDelete(false);
        }
    }
}