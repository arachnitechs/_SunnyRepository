
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PalmSecure
{
    public enum PS_APP_EXCEPTION
    {
        PVS_APPEX_OK            = 0,   /* OK */

        PS_APPEX_BMP_SAVE      = 100, /* Failed to save silhouette file. */
        PS_APPEX_BMPDIR_OPEN,         /* Failed to open silhouette dir. */
        PS_APPEX_LOGDIR_OPEN,         /* Failed to open log dir. */
        PS_APPEX_LOGFILE_OPEN,        /* Failed to open log file. */
        PS_APPEX_LOGFILE_WRITE,       /* Failed to write log file. */
        PS_APPEX_FILEDIR_OPEN,        /* Failed to open data dir. */
        PS_APPEX_FILE_OPEN,           /* Failed to open data file. */
        PS_APPEX_FILE_WRITE,          /* Failed to write data file. */
        PS_APPEX_FILE_DELETE,         /* Failed to delete data file. */
        PS_APPEX_FILE_NOTFOUND,       /* Failed to find data file. */
        PS_APPEX_NODATA_FOUND,        /* here is no setting data. */
        PS_APPEX_GUIDEBMP_LOAD,       /* Failed to load guidance image file. */
        PS_APPEX_SILHOUETTE_LOAD,     /* Failed to load silhouette image. */
        PS_APPEX_SYSTEM_ERROR         /* System Error. */
    }

    public enum PS_WRK_MESSAGE
    {
        PS_MESSAGE_ENROLL_START = 1,
        PS_MESSAGE_ENROLL = 2,
        PS_MESSAGE_ENROLL_TEST = 3,
        PS_MESSAGE_IDENTIFY_START = 11,
        PS_MESSAGE_IDENTIFY = 12,
        PS_MESSAGE_VERIFY_START = 21,
        PS_MESSAGE_VERIFY = 22,
        PS_MESSAGE_DELETE = 32
    }

    class PsCommon
    {

    }
}
