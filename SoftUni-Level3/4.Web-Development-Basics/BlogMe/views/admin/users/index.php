<!--TODO: to check for some template or redesign the page-->
<h2>Admin Users View</h2
<br />
<table>
    <tr>
        <th>Id</th>
        <th>Username</th>
        <th>FullName</th>
        <th>Email</th>
    </tr>
<?php foreach ($users as $user): ?>
    <tr>
        <td><?php echo $user['Id'] ?></td>
        <td><?php echo $user['Username'] ?></td>
        <td><?php echo $user['FullName'] ?></td>
        <td><?php echo $user['Email'] ?></td>
    </tr>
<?php endforeach; ?>
</table>