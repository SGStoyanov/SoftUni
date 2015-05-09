<div class="container">
    <div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-8">
            <form method="post" role="form">
                <div class="form-group">
                    <label for="title">Title: </label>
                        <input type="text" id="title" class="form-control" required name="title"
                               value="<?php if( isset( $this -> formValues['title'] ) ) {
                                   echo( $this -> getFieldValue('title') );
                               }
                               ?>"/>
                        <?php if( isset( $this -> validationErrors['title'] ) ) {
                            echo $this -> getValidationError('title');
                        } ?>
                        <label for="content">Content: </label>
                        <textarea id="content" rows="12" class="form-control" required name="content"
                               value="<?php if( isset( $this -> formValues['content'] ) ) {
                                   echo( $this -> getFieldValue('content') );
                               }
                               ?>">
                        </textarea>
                        <?php if( isset( $this -> validationErrors['content'] ) ) {
                            echo  $this -> getValidationError('content');
                        }
                        ?>
                        <label for="tags">Tags (separated by comma): </label>
                        <input type="text" id="tags" class="form-control" required name="tags"
                               value="<?php if( isset( $this -> formValues['tags'] ) ) {
                                   echo( $this -> getFieldValue('tags') );
                               }
                               ?>"/>
                        <?php if( isset( $this -> validationErrors['tags'] ) ) {
                            echo $this -> getValidationError('tags');
                        }
                        ?>
                        <br />
                        <input type="submit" value="Submit" class="btn btn-primary" />
                </div>
            </form>
        </div>
    </div>