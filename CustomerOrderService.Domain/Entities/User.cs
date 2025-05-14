using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Intrinsics.X86;

namespace CustomerOrderService.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        [Required, StringLength(100), EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(256)]
        public string PasswordHash { get; set; }
        [Required, StringLength(20)]
        public string Role { get; set; } = "User";
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        /*-- Generate a BCrypt hashed password for 'AdminPassword123'
            -- You can use an online BCrypt hash generator or a tool like Python's bcrypt
            -- Example hashed password(replace with your own) :
            DECLARE @PasswordHash NVARCHAR(256) = '$2a$11$6z8z9y0x1w2v3u4t5r6q7p8o9i0j1k2l3m4n5o6p7q8r9s0t1u2v';

            INSERT INTO Users(UserId, Email, PasswordHash, Role, CreatedAt)
            VALUES(NEWID(), 'admin@example.com', @PasswordHash, 'Admin', GETUTCDATE());
        */
    }
}