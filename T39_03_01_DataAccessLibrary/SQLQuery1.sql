﻿

select p.*
from dbo.PhoneNumbers p
inner join dbo.ContactPhoneNumbers cp on cp.PhoneNumberId = p.Id
where cp.ContactId = 1