USE db_contacts;

INSERT INTO Contacts (FirstName, LastName) VALUES ('Tim', 'Corey');
INSERT INTO EmailAddresses (EmailAddress) VALUES ('tim@iamtimcorey.com'), ('me@timothycorey.com');
INSERT INTO PhoneNumbers (PhoneNumber) VALUES ('555-1212'), ('555-1234');
INSERT INTO ContactEmailAddresses (ContactId, EmailAddressId) VALUES (1, 1), (1, 2);
INSERT INTO ContactPhoneNumbers (ContactId, PhoneNumberId) VALUES (1, 1), (1, 2);

SELECT * FROM Contacts;
SELECT * FROM EmailAddresses;
SELECT * FROM PhoneNumbers;
SELECT * FROM ContactEmailAddresses;
SELECT * FROM ContactPhoneNumbers;
