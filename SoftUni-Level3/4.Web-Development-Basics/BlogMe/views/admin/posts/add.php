<form method="post">
    <p>
        <label for="title">Title: </label>
        <input type="text" required name="title" />
    </p>
    <p>
        <label for="content">Content: </label>
        <textarea id="post-content-textbox" required name="content"></textarea>
    </p>
    <p>
        <label for="tags">Tags(separated by comma): </label>
        <input type="text" required name="tags" />
    </p>
    <input type="submit" value="Submit" />
</form>