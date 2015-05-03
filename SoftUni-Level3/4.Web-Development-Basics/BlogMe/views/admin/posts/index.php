<!--TODO: to check for some template or redesign the page-->
<h2>Admin Posts View</h2
<br />
<table>
    <tr>
        <th>Id</th>
        <th>Title</th>
        <th>Content</th>
        <th>Visits</th>
        <th>Date Published</th>
        <th>User</th>
        <th>Tags</th>
    </tr>
    <?php foreach ($posts as $post): ?>
    <tr>
        <td><?php echo htmlspecialchars( $post['Id'] ) ?></td>
        <td><?php echo htmlspecialchars( $post['Title'] ) ?></td>
        <td><?php echo htmlspecialchars( $post['Content'] ) ?></td>
        <td><?php echo htmlspecialchars( $post['Visits'] ) ?></td>
        <td><?php echo htmlspecialchars( $post['Date_Published'] ) ?></td>
        <td><?php echo htmlspecialchars( $post['User_Id'] ) ?></td>
        <td>
            <?php
                foreach( $tags[$post['Id']] as $tag_array ) {
                    foreach( $tag_array as $tag ) {
                        echo htmlspecialchars( "$tag " );
                    }
                }
            ?>
        </td>
    <?php endforeach; ?>
    </tr>
</table>