<form method="post">
    <p>
        <label for="title">New Title: </label>
        <input type="text" name="title" value="<?php echo addslashes($post['Title']) ?>" />
    </p>
    <p>
        <label for="content">New Content: </label>
        <input type="text" name="content" value="<?php echo addslashes($post['Content']) ?>" />
    </p>
    <input type="hidden" name="id" value="<?php echo addslashes($post['Id']) ?>" />
    <input type="submit" value="Submit" />
</form>