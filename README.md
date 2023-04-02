# Event Management API

## Solution Structure

![ProjectStructure](https://user-images.githubusercontent.com/80807793/229363545-76151611-e718-4841-bef8-4fd25dc0000b.jpg)

## Setup Instructions

### The database is SQLite, so you don't need to configure it. Also there is seed Users data in database, imported from API.
### You just need to run docker container. Go to Solution directory and use this commands
```
docker compose build 
```
after
```
docker compose up
```
## Functionality

### /api/Events/Create - Create new event for user
### /api/Events/Update - Update user's existing event
### /api/Events/GetById - Get event by id
### /api/Events/GetAllByUserId - Get user's all events with paging
### /api/Events/GetAll - Get all events with paging
### /api/Events/Delete - Delete user's event
### /api/Events/Participate - Participate in ivent
### /api/Events/SendInvitation - Send invitation to another user
### /api/Events/GetReceivedInvitations - Get current user's received invitations
### /api/Events/GetSentInvitations - Get current user's sent invitations
