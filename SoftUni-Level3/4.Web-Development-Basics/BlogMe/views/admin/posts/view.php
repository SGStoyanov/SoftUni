<!--TODO: to check for some template or redesign the page-->
<h2>Admin Users View</h2
<br />
<table>
    <tr>
        <th>Post Id</th>
        <th>Title</th>
        <th>Content</th>
        <th>Visits</th>
        <th>Posted by User Id</th>
        <th>Posted by User</th>
    </tr>
    <tr>
        <td><?php echo $posts['Id'] ?></td>
        <td><?php echo $posts['Title'] ?></td>
        <td><?php echo $posts['Content'] ?></td>
        <td><?php echo $posts['Visits'] ?></td>
        <td><?php echo $user['Id'] ?></td>
        <td><?php echo $user['Username'] ?></td>
    </tr>
</table>