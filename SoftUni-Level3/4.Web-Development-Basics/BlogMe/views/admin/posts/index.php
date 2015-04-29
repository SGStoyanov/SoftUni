<!--TODO: to check for some template or redesign the page-->
<h2>Admin Posts View</h2
<br />
<table>
    <tr>
        <th>Id</th>
        <th>Title</th>
        <th>Content</th>
        <th>Visits</th>
        <th>User</th>
    </tr>
    <?php foreach ($posts as $post): ?>
    <tr>
        <td><?php echo $post['Id'] ?></td>
        <td><?php echo $post['Title'] ?></td>
        <td><?php echo $post['Content'] ?></td>
        <td><?php echo $post['Visits'] ?></td>
        <td><?php echo $post['User_Id'] ?></td>
    </tr>
    <?php endforeach; ?>
</table>