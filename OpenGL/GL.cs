using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExtraForms.OpenGL
{
    public static class GL
    {
        public const uint ZERO = 0;
        public const byte FALSE = 0;
        public const uint LOGIC_OP = 0x0BF1;
        public const uint NONE = 0;
        public const uint TEXTURE_COMPONENTS = 0x1003;
        public const uint NO_ERROR = 0;
        public const uint POINTS = 0x0000;
        public const uint CURRENT_BIT = 0x00000001;
        public const uint TRUE = 1;
        public const uint ONE = 1;
        public const uint CLIENT_PIXEL_STORE_BIT = 0x00000001;
        public const uint LINES = 0x0001;
        public const uint LINE_LOOP = 0x0002;
        public const uint POINT_BIT = 0x00000002;
        public const uint CLIENT_VERTEX_ARRAY_BIT = 0x00000002;
        public const uint LINE_STRIP = 0x0003;
        public const uint LINE_BIT = 0x00000004;
        public const uint TRIANGLES = 0x0004;
        public const uint TRIANGLE_STRIP = 0x0005;
        public const uint TRIANGLE_FAN = 0x0006;
        public const uint QUADS = 0x0007;
        public const uint QUAD_STRIP = 0x0008;
        public const uint POLYGON_BIT = 0x00000008;
        public const uint POLYGON = 0x0009;
        public const uint POLYGON_STIPPLE_BIT = 0x00000010;
        public const uint PIXEL_MODE_BIT = 0x00000020;
        public const uint LIGHTING_BIT = 0x00000040;
        public const uint FOG_BIT = 0x00000080;
        public const uint DEPTH_BUFFER_BIT = 0x00000100;
        public const uint ACCUM = 0x0100;
        public const uint LOAD = 0x0101;
        public const uint RETURN = 0x0102;
        public const uint MULT = 0x0103;
        public const uint ADD = 0x0104;
        public const uint NEVER = 0x0200;
        public const uint ACCUM_BUFFER_BIT = 0x00000200;
        public const uint LESS = 0x0201;
        public const uint EQUAL = 0x0202;
        public const uint LEQUAL = 0x0203;
        public const uint GREATER = 0x0204;
        public const uint NOTEQUAL = 0x0205;
        public const uint GEQUAL = 0x0206;
        public const uint ALWAYS = 0x0207;
        public const uint SRC_COLOR = 0x0300;
        public const uint ONE_MINUS_SRC_COLOR = 0x0301;
        public const uint SRC_ALPHA = 0x0302;
        public const uint ONE_MINUS_SRC_ALPHA = 0x0303;
        public const uint DST_ALPHA = 0x0304;
        public const uint ONE_MINUS_DST_ALPHA = 0x0305;
        public const uint DST_COLOR = 0x0306;
        public const uint ONE_MINUS_DST_COLOR = 0x0307;
        public const uint SRC_ALPHA_SATURATE = 0x0308;
        public const uint STENCIL_BUFFER_BIT = 0x00000400;
        public const uint FRONT_LEFT = 0x0400;
        public const uint FRONT_RIGHT = 0x0401;
        public const uint BACK_LEFT = 0x0402;
        public const uint BACK_RIGHT = 0x0403;
        public const uint FRONT = 0x0404;
        public const uint BACK = 0x0405;
        public const uint LEFT = 0x0406;
        public const uint RIGHT = 0x0407;
        public const uint FRONT_AND_BACK = 0x0408;
        public const uint AUX0 = 0x0409;
        public const uint AUX1 = 0x040A;
        public const uint AUX2 = 0x040B;
        public const uint AUX3 = 0x040C;
        public const uint INVALID_ENUM = 0x0500;
        public const uint INVALID_VALUE = 0x0501;
        public const uint INVALID_OPERATION = 0x0502;
        public const uint STACK_OVERFLOW = 0x0503;
        public const uint STACK_UNDERFLOW = 0x0504;
        public const uint OUT_OF_MEMORY = 0x0505;
        public const uint _2D = 0x0600;
        public const uint _3D = 0x0601;
        public const uint _3D_COLOR = 0x0602;
        public const uint _3D_COLOR_TEXTURE = 0x0603;
        public const uint _4D_COLOR_TEXTURE = 0x0604;
        public const uint PASS_THROUGH_TOKEN = 0x0700;
        public const uint POINT_TOKEN = 0x0701;
        public const uint LINE_TOKEN = 0x0702;
        public const uint POLYGON_TOKEN = 0x0703;
        public const uint BITMAP_TOKEN = 0x0704;
        public const uint DRAW_PIXEL_TOKEN = 0x0705;
        public const uint COPY_PIXEL_TOKEN = 0x0706;
        public const uint LINE_RESET_TOKEN = 0x0707;
        public const uint EXP = 0x0800;
        public const uint VIEWPORT_BIT = 0x00000800;
        public const uint EXP2 = 0x0801;
        public const uint CW = 0x0900;
        public const uint CCW = 0x0901;
        public const uint COEFF = 0x0A00;
        public const uint ORDER = 0x0A01;
        public const uint DOMAIN = 0x0A02;
        public const uint CURRENT_COLOR = 0x0B00;
        public const uint CURRENT_INDEX = 0x0B01;
        public const uint CURRENT_NORMAL = 0x0B02;
        public const uint CURRENT_TEXTURE_COORDS = 0x0B03;
        public const uint CURRENT_RASTER_COLOR = 0x0B04;
        public const uint CURRENT_RASTER_INDEX = 0x0B05;
        public const uint CURRENT_RASTER_TEXTURE_COORDS = 0x0B06;
        public const uint CURRENT_RASTER_POSITION = 0x0B07;
        public const uint CURRENT_RASTER_POSITION_VALID = 0x0B08;
        public const uint CURRENT_RASTER_DISTANCE = 0x0B09;
        public const uint POINT_SMOOTH = 0x0B10;
        public const uint POINT_SIZE = 0x0B11;
        public const uint POINT_SIZE_RANGE = 0x0B12;
        public const uint POINT_SIZE_GRANULARITY = 0x0B13;
        public const uint LINE_SMOOTH = 0x0B20;
        public const uint LINE_WIDTH = 0x0B21;
        public const uint LINE_WIDTH_RANGE = 0x0B22;
        public const uint LINE_WIDTH_GRANULARITY = 0x0B23;
        public const uint LINE_STIPPLE = 0x0B24;
        public const uint LINE_STIPPLE_PATTERN = 0x0B25;
        public const uint LINE_STIPPLE_REPEAT = 0x0B26;
        public const uint LIST_MODE = 0x0B30;
        public const uint MAX_LIST_NESTING = 0x0B31;
        public const uint LIST_BASE = 0x0B32;
        public const uint LIST_INDEX = 0x0B33;
        public const uint POLYGON_MODE = 0x0B40;
        public const uint POLYGON_SMOOTH = 0x0B41;
        public const uint POLYGON_STIPPLE = 0x0B42;
        public const uint EDGE_FLAG = 0x0B43;
        public const uint CULL_FACE = 0x0B44;
        public const uint CULL_FACE_MODE = 0x0B45;
        public const uint FRONT_FACE = 0x0B46;
        public const uint LIGHTING = 0x0B50;
        public const uint LIGHT_MODEL_LOCAL_VIEWER = 0x0B51;
        public const uint LIGHT_MODEL_TWO_SIDE = 0x0B52;
        public const uint LIGHT_MODEL_AMBIENT = 0x0B53;
        public const uint SHADE_MODEL = 0x0B54;
        public const uint COLOR_MATERIAL_FACE = 0x0B55;
        public const uint COLOR_MATERIAL_PARAMETER = 0x0B56;
        public const uint COLOR_MATERIAL = 0x0B57;
        public const uint FOG = 0x0B60;
        public const uint FOG_INDEX = 0x0B61;
        public const uint FOG_DENSITY = 0x0B62;
        public const uint FOG_START = 0x0B63;
        public const uint FOG_END = 0x0B64;
        public const uint FOG_MODE = 0x0B65;
        public const uint FOG_COLOR = 0x0B66;
        public const uint DEPTH_RANGE = 0x0B70;
        public const uint DEPTH_TEST = 0x0B71;
        public const uint DEPTH_WRITEMASK = 0x0B72;
        public const uint DEPTH_CLEAR_VALUE = 0x0B73;
        public const uint DEPTH_FUNC = 0x0B74;
        public const uint ACCUM_CLEAR_VALUE = 0x0B80;
        public const uint STENCIL_TEST = 0x0B90;
        public const uint STENCIL_CLEAR_VALUE = 0x0B91;
        public const uint STENCIL_FUNC = 0x0B92;
        public const uint STENCIL_VALUE_MASK = 0x0B93;
        public const uint STENCIL_FAIL = 0x0B94;
        public const uint STENCIL_PASS_DEPTH_FAIL = 0x0B95;
        public const uint STENCIL_PASS_DEPTH_PASS = 0x0B96;
        public const uint STENCIL_REF = 0x0B97;
        public const uint STENCIL_WRITEMASK = 0x0B98;
        public const uint MATRIX_MODE = 0x0BA0;
        public const uint NORMALIZE = 0x0BA1;
        public const uint VIEWPORT = 0x0BA2;
        public const uint MODELVIEW_STACK_DEPTH = 0x0BA3;
        public const uint PROJECTION_STACK_DEPTH = 0x0BA4;
        public const uint TEXTURE_STACK_DEPTH = 0x0BA5;
        public const uint MODELVIEW_MATRIX = 0x0BA6;
        public const uint PROJECTION_MATRIX = 0x0BA7;
        public const uint TEXTURE_MATRIX = 0x0BA8;
        public const uint ATTRIB_STACK_DEPTH = 0x0BB0;
        public const uint CLIENT_ATTRIB_STACK_DEPTH = 0x0BB1;
        public const uint ALPHA_TEST = 0x0BC0;
        public const uint ALPHA_TEST_FUNC = 0x0BC1;
        public const uint ALPHA_TEST_REF = 0x0BC2;
        public const uint DITHER = 0x0BD0;
        public const uint BLEND_DST = 0x0BE0;
        public const uint BLEND_SRC = 0x0BE1;
        public const uint BLEND = 0x0BE2;
        public const uint LOGIC_OP_MODE = 0x0BF0;
        public const uint INDEX_LOGIC_OP = 0x0BF1;
        public const uint COLOR_LOGIC_OP = 0x0BF2;
        public const uint AUX_BUFFERS = 0x0C00;
        public const uint DRAW_BUFFER = 0x0C01;
        public const uint READ_BUFFER = 0x0C02;
        public const uint SCISSOR_BOX = 0x0C10;
        public const uint SCISSOR_TEST = 0x0C11;
        public const uint INDEX_CLEAR_VALUE = 0x0C20;
        public const uint INDEX_WRITEMASK = 0x0C21;
        public const uint COLOR_CLEAR_VALUE = 0x0C22;
        public const uint COLOR_WRITEMASK = 0x0C23;
        public const uint INDEX_MODE = 0x0C30;
        public const uint RGBA_MODE = 0x0C31;
        public const uint DOUBLEBUFFER = 0x0C32;
        public const uint STEREO = 0x0C33;
        public const uint RENDER_MODE = 0x0C40;
        public const uint PERSPECTIVE_CORRECTION_HINT = 0x0C50;
        public const uint POINT_SMOOTH_HINT = 0x0C51;
        public const uint LINE_SMOOTH_HINT = 0x0C52;
        public const uint POLYGON_SMOOTH_HINT = 0x0C53;
        public const uint FOG_HINT = 0x0C54;
        public const uint TEXTURE_GEN_S = 0x0C60;
        public const uint TEXTURE_GEN_T = 0x0C61;
        public const uint TEXTURE_GEN_R = 0x0C62;
        public const uint TEXTURE_GEN_Q = 0x0C63;
        public const uint PIXEL_MAP_I_TO_I = 0x0C70;
        public const uint PIXEL_MAP_S_TO_S = 0x0C71;
        public const uint PIXEL_MAP_I_TO_R = 0x0C72;
        public const uint PIXEL_MAP_I_TO_G = 0x0C73;
        public const uint PIXEL_MAP_I_TO_B = 0x0C74;
        public const uint PIXEL_MAP_I_TO_A = 0x0C75;
        public const uint PIXEL_MAP_R_TO_R = 0x0C76;
        public const uint PIXEL_MAP_G_TO_G = 0x0C77;
        public const uint PIXEL_MAP_B_TO_B = 0x0C78;
        public const uint PIXEL_MAP_A_TO_A = 0x0C79;
        public const uint PIXEL_MAP_I_TO_I_SIZE = 0x0CB0;
        public const uint PIXEL_MAP_S_TO_S_SIZE = 0x0CB1;
        public const uint PIXEL_MAP_I_TO_R_SIZE = 0x0CB2;
        public const uint PIXEL_MAP_I_TO_G_SIZE = 0x0CB3;
        public const uint PIXEL_MAP_I_TO_B_SIZE = 0x0CB4;
        public const uint PIXEL_MAP_I_TO_A_SIZE = 0x0CB5;
        public const uint PIXEL_MAP_R_TO_R_SIZE = 0x0CB6;
        public const uint PIXEL_MAP_G_TO_G_SIZE = 0x0CB7;
        public const uint PIXEL_MAP_B_TO_B_SIZE = 0x0CB8;
        public const uint PIXEL_MAP_A_TO_A_SIZE = 0x0CB9;
        public const uint UNPACK_SWAP_BYTES = 0x0CF0;
        public const uint UNPACK_LSB_FIRST = 0x0CF1;
        public const uint UNPACK_ROW_LENGTH = 0x0CF2;
        public const uint UNPACK_SKIP_ROWS = 0x0CF3;
        public const uint UNPACK_SKIP_PIXELS = 0x0CF4;
        public const uint UNPACK_ALIGNMENT = 0x0CF5;
        public const uint PACK_SWAP_BYTES = 0x0D00;
        public const uint PACK_LSB_FIRST = 0x0D01;
        public const uint PACK_ROW_LENGTH = 0x0D02;
        public const uint PACK_SKIP_ROWS = 0x0D03;
        public const uint PACK_SKIP_PIXELS = 0x0D04;
        public const uint PACK_ALIGNMENT = 0x0D05;
        public const uint MAP_COLOR = 0x0D10;
        public const uint MAP_STENCIL = 0x0D11;
        public const uint INDEX_SHIFT = 0x0D12;
        public const uint INDEX_OFFSET = 0x0D13;
        public const uint RED_SCALE = 0x0D14;
        public const uint RED_BIAS = 0x0D15;
        public const uint ZOOM_X = 0x0D16;
        public const uint ZOOM_Y = 0x0D17;
        public const uint GREEN_SCALE = 0x0D18;
        public const uint GREEN_BIAS = 0x0D19;
        public const uint BLUE_SCALE = 0x0D1A;
        public const uint BLUE_BIAS = 0x0D1B;
        public const uint ALPHA_SCALE = 0x0D1C;
        public const uint ALPHA_BIAS = 0x0D1D;
        public const uint DEPTH_SCALE = 0x0D1E;
        public const uint DEPTH_BIAS = 0x0D1F;
        public const uint MAX_EVAL_ORDER = 0x0D30;
        public const uint MAX_LIGHTS = 0x0D31;
        public const uint MAX_CLIP_PLANES = 0x0D32;
        public const uint MAX_TEXTURE_SIZE = 0x0D33;
        public const uint MAX_PIXEL_MAP_TABLE = 0x0D34;
        public const uint MAX_ATTRIB_STACK_DEPTH = 0x0D35;
        public const uint MAX_MODELVIEW_STACK_DEPTH = 0x0D36;
        public const uint MAX_NAME_STACK_DEPTH = 0x0D37;
        public const uint MAX_PROJECTION_STACK_DEPTH = 0x0D38;
        public const uint MAX_TEXTURE_STACK_DEPTH = 0x0D39;
        public const uint MAX_VIEWPORT_DIMS = 0x0D3A;
        public const uint MAX_CLIENT_ATTRIB_STACK_DEPTH = 0x0D3B;
        public const uint SUBPIXEL_BITS = 0x0D50;
        public const uint INDEX_BITS = 0x0D51;
        public const uint RED_BITS = 0x0D52;
        public const uint GREEN_BITS = 0x0D53;
        public const uint BLUE_BITS = 0x0D54;
        public const uint ALPHA_BITS = 0x0D55;
        public const uint DEPTH_BITS = 0x0D56;
        public const uint STENCIL_BITS = 0x0D57;
        public const uint ACCUM_RED_BITS = 0x0D58;
        public const uint ACCUM_GREEN_BITS = 0x0D59;
        public const uint ACCUM_BLUE_BITS = 0x0D5A;
        public const uint ACCUM_ALPHA_BITS = 0x0D5B;
        public const uint NAME_STACK_DEPTH = 0x0D70;
        public const uint AUTO_NORMAL = 0x0D80;
        public const uint MAP1_COLOR_4 = 0x0D90;
        public const uint MAP1_INDEX = 0x0D91;
        public const uint MAP1_NORMAL = 0x0D92;
        public const uint MAP1_TEXTURE_COORD_1 = 0x0D93;
        public const uint MAP1_TEXTURE_COORD_2 = 0x0D94;
        public const uint MAP1_TEXTURE_COORD_3 = 0x0D95;
        public const uint MAP1_TEXTURE_COORD_4 = 0x0D96;
        public const uint MAP1_VERTEX_3 = 0x0D97;
        public const uint MAP1_VERTEX_4 = 0x0D98;
        public const uint MAP2_COLOR_4 = 0x0DB0;
        public const uint MAP2_INDEX = 0x0DB1;
        public const uint MAP2_NORMAL = 0x0DB2;
        public const uint MAP2_TEXTURE_COORD_1 = 0x0DB3;
        public const uint MAP2_TEXTURE_COORD_2 = 0x0DB4;
        public const uint MAP2_TEXTURE_COORD_3 = 0x0DB5;
        public const uint MAP2_TEXTURE_COORD_4 = 0x0DB6;
        public const uint MAP2_VERTEX_3 = 0x0DB7;
        public const uint MAP2_VERTEX_4 = 0x0DB8;
        public const uint MAP1_GRID_DOMAIN = 0x0DD0;
        public const uint MAP1_GRID_SEGMENTS = 0x0DD1;
        public const uint MAP2_GRID_DOMAIN = 0x0DD2;
        public const uint MAP2_GRID_SEGMENTS = 0x0DD3;
        public const uint TEXTURE_1D = 0x0DE0;
        public const uint TEXTURE_2D = 0x0DE1;
        public const uint FEEDBACK_BUFFER_POINTER = 0x0DF0;
        public const uint FEEDBACK_BUFFER_SIZE = 0x0DF1;
        public const uint FEEDBACK_BUFFER_TYPE = 0x0DF2;
        public const uint SELECTION_BUFFER_POINTER = 0x0DF3;
        public const uint SELECTION_BUFFER_SIZE = 0x0DF4;
        public const uint TEXTURE_WIDTH = 0x1000;
        public const uint TRANSFORM_BIT = 0x00001000;
        public const uint TEXTURE_HEIGHT = 0x1001;
        public const uint TEXTURE_INTERNAL_FORMAT = 0x1003;
        public const uint TEXTURE_BORDER_COLOR = 0x1004;
        public const uint TEXTURE_BORDER = 0x1005;
        public const uint DONT_CARE = 0x1100;
        public const uint FASTEST = 0x1101;
        public const uint NICEST = 0x1102;
        public const uint AMBIENT = 0x1200;
        public const uint DIFFUSE = 0x1201;
        public const uint SPECULAR = 0x1202;
        public const uint POSITION = 0x1203;
        public const uint SPOT_DIRECTION = 0x1204;
        public const uint SPOT_EXPONENT = 0x1205;
        public const uint SPOT_CUTOFF = 0x1206;
        public const uint CONSTANT_ATTENUATION = 0x1207;
        public const uint LINEAR_ATTENUATION = 0x1208;
        public const uint QUADRATIC_ATTENUATION = 0x1209;
        public const uint COMPILE = 0x1300;
        public const uint COMPILE_AND_EXECUTE = 0x1301;
        public const uint BYTE = 0x1400;
        public const uint UNSIGNED_BYTE = 0x1401;
        public const uint SHORT = 0x1402;
        public const uint UNSIGNED_SHORT = 0x1403;
        public const uint INT = 0x1404;
        public const uint UNSIGNED_INT = 0x1405;
        public const uint FLOAT = 0x1406;
        public const uint _2_BYTES = 0x1407;
        public const uint _3_BYTES = 0x1408;
        public const uint _4_BYTES = 0x1409;
        public const uint DOUBLE = 0x140A;
        public const uint CLEAR = 0x1500;
        public const uint AND = 0x1501;
        public const uint AND_REVERSE = 0x1502;
        public const uint COPY = 0x1503;
        public const uint AND_INVERTED = 0x1504;
        public const uint NOOP = 0x1505;
        public const uint XOR = 0x1506;
        public const uint OR = 0x1507;
        public const uint NOR = 0x1508;
        public const uint EQUIV = 0x1509;
        public const uint INVERT = 0x150A;
        public const uint OR_REVERSE = 0x150B;
        public const uint COPY_INVERTED = 0x150C;
        public const uint OR_INVERTED = 0x150D;
        public const uint NAND = 0x150E;
        public const uint SET = 0x150F;
        public const uint EMISSION = 0x1600;
        public const uint SHININESS = 0x1601;
        public const uint AMBIENT_AND_DIFFUSE = 0x1602;
        public const uint COLOR_INDEXES = 0x1603;
        public const uint MODELVIEW = 0x1700;
        public const uint PROJECTION = 0x1701;
        public const uint TEXTURE = 0x1702;
        public const uint COLOR = 0x1800;
        public const uint DEPTH = 0x1801;
        public const uint STENCIL = 0x1802;
        public const uint COLOR_INDEX = 0x1900;
        public const uint STENCIL_INDEX = 0x1901;
        public const uint DEPTH_COMPONENT = 0x1902;
        public const uint RED = 0x1903;
        public const uint GREEN = 0x1904;
        public const uint BLUE = 0x1905;
        public const uint ALPHA = 0x1906;
        public const uint RGB = 0x1907;
        public const int RGBA = 0x1908;
        public const uint LUMINANCE = 0x1909;
        public const uint LUMINANCE_ALPHA = 0x190A;
        public const uint BITMAP = 0x1A00;
        public const uint POINT = 0x1B00;
        public const uint LINE = 0x1B01;
        public const uint FILL = 0x1B02;
        public const uint RENDER = 0x1C00;
        public const uint FEEDBACK = 0x1C01;
        public const uint SELECT = 0x1C02;
        public const uint FLAT = 0x1D00;
        public const uint SMOOTH = 0x1D01;
        public const uint KEEP = 0x1E00;
        public const uint REPLACE = 0x1E01;
        public const uint INCR = 0x1E02;
        public const uint DECR = 0x1E03;
        public const uint VENDOR = 0x1F00;
        public const uint RENDERER = 0x1F01;
        public const uint VERSION = 0x1F02;
        public const uint EXTENSIONS = 0x1F03;
        public const uint S = 0x2000;
        public const uint ENABLE_BIT = 0x00002000;
        public const uint T = 0x2001;
        public const uint R = 0x2002;
        public const uint Q = 0x2003;
        public const uint MODULATE = 0x2100;
        public const uint DECAL = 0x2101;
        public const uint TEXTURE_ENV_MODE = 0x2200;
        public const uint TEXTURE_ENV_COLOR = 0x2201;
        public const uint TEXTURE_ENV = 0x2300;
        public const uint EYE_LINEAR = 0x2400;
        public const uint OBJECT_LINEAR = 0x2401;
        public const uint SPHERE_MAP = 0x2402;
        public const uint TEXTURE_GEN_MODE = 0x2500;
        public const uint OBJECT_PLANE = 0x2501;
        public const uint EYE_PLANE = 0x2502;
        public const int NEAREST = 0x2600;
        public const uint LINEAR = 0x2601;
        public const uint NEAREST_MIPMAP_NEAREST = 0x2700;
        public const uint LINEAR_MIPMAP_NEAREST = 0x2701;
        public const uint NEAREST_MIPMAP_LINEAR = 0x2702;
        public const uint LINEAR_MIPMAP_LINEAR = 0x2703;
        public const uint TEXTURE_MAG_FILTER = 0x2800;
        public const uint TEXTURE_MIN_FILTER = 0x2801;
        public const uint TEXTURE_WRAP_S = 0x2802;
        public const uint TEXTURE_WRAP_T = 0x2803;
        public const int CLAMP = 0x2900;
        public const uint REPEAT = 0x2901;
        public const uint POLYGON_OFFSET_UNITS = 0x2A00;
        public const uint POLYGON_OFFSET_POINT = 0x2A01;
        public const uint POLYGON_OFFSET_LINE = 0x2A02;
        public const uint R3_G3_B2 = 0x2A10;
        public const uint V2F = 0x2A20;
        public const uint V3F = 0x2A21;
        public const uint C4UB_V2F = 0x2A22;
        public const uint C4UB_V3F = 0x2A23;
        public const uint C3F_V3F = 0x2A24;
        public const uint N3F_V3F = 0x2A25;
        public const uint C4F_N3F_V3F = 0x2A26;
        public const uint T2F_V3F = 0x2A27;
        public const uint T4F_V4F = 0x2A28;
        public const uint T2F_C4UB_V3F = 0x2A29;
        public const uint T2F_C3F_V3F = 0x2A2A;
        public const uint T2F_N3F_V3F = 0x2A2B;
        public const uint T2F_C4F_N3F_V3F = 0x2A2C;
        public const uint T4F_C4F_N3F_V4F = 0x2A2D;
        public const uint CLIP_PLANE0 = 0x3000;
        public const uint CLIP_PLANE1 = 0x3001;
        public const uint CLIP_PLANE2 = 0x3002;
        public const uint CLIP_PLANE3 = 0x3003;
        public const uint CLIP_PLANE4 = 0x3004;
        public const uint CLIP_PLANE5 = 0x3005;
        public const uint LIGHT0 = 0x4000;
        public const uint COLOR_BUFFER_BIT = 0x00004000;
        public const uint LIGHT1 = 0x4001;
        public const uint LIGHT2 = 0x4002;
        public const uint LIGHT3 = 0x4003;
        public const uint LIGHT4 = 0x4004;
        public const uint LIGHT5 = 0x4005;
        public const uint LIGHT6 = 0x4006;
        public const uint LIGHT7 = 0x4007;
        public const uint HINT_BIT = 0x00008000;
        public const uint POLYGON_OFFSET_FILL = 0x8037;
        public const uint POLYGON_OFFSET_FACTOR = 0x8038;
        public const uint ALPHA4 = 0x803B;
        public const uint ALPHA8 = 0x803C;
        public const uint ALPHA12 = 0x803D;
        public const uint ALPHA16 = 0x803E;
        public const uint LUMINANCE4 = 0x803F;
        public const uint LUMINANCE8 = 0x8040;
        public const uint LUMINANCE12 = 0x8041;
        public const uint LUMINANCE16 = 0x8042;
        public const uint LUMINANCE4_ALPHA4 = 0x8043;
        public const uint LUMINANCE6_ALPHA2 = 0x8044;
        public const uint LUMINANCE8_ALPHA8 = 0x8045;
        public const uint LUMINANCE12_ALPHA4 = 0x8046;
        public const uint LUMINANCE12_ALPHA12 = 0x8047;
        public const uint LUMINANCE16_ALPHA16 = 0x8048;
        public const uint INTENSITY = 0x8049;
        public const uint INTENSITY4 = 0x804A;
        public const uint INTENSITY8 = 0x804B;
        public const uint INTENSITY12 = 0x804C;
        public const uint INTENSITY16 = 0x804D;
        public const uint RGB4 = 0x804F;
        public const uint RGB5 = 0x8050;
        public const uint RGB8 = 0x8051;
        public const uint RGB10 = 0x8052;
        public const uint RGB12 = 0x8053;
        public const uint RGB16 = 0x8054;
        public const uint RGBA2 = 0x8055;
        public const uint RGBA4 = 0x8056;
        public const uint RGB5_A1 = 0x8057;
        public const uint RGBA8 = 0x8058;
        public const uint RGB10_A2 = 0x8059;
        public const uint RGBA12 = 0x805A;
        public const uint RGBA16 = 0x805B;
        public const uint TEXTURE_RED_SIZE = 0x805C;
        public const uint TEXTURE_GREEN_SIZE = 0x805D;
        public const uint TEXTURE_BLUE_SIZE = 0x805E;
        public const uint TEXTURE_ALPHA_SIZE = 0x805F;
        public const uint TEXTURE_LUMINANCE_SIZE = 0x8060;
        public const uint TEXTURE_INTENSITY_SIZE = 0x8061;
        public const uint PROXY_TEXTURE_1D = 0x8063;
        public const uint PROXY_TEXTURE_2D = 0x8064;
        public const uint TEXTURE_PRIORITY = 0x8066;
        public const uint TEXTURE_RESIDENT = 0x8067;
        public const uint TEXTURE_BINDING_1D = 0x8068;
        public const uint TEXTURE_BINDING_2D = 0x8069;
        public const uint VERTEX_ARRAY = 0x8074;
        public const uint NORMAL_ARRAY = 0x8075;
        public const uint COLOR_ARRAY = 0x8076;
        public const uint INDEX_ARRAY = 0x8077;
        public const uint TEXTURE_COORD_ARRAY = 0x8078;
        public const uint EDGE_FLAG_ARRAY = 0x8079;
        public const uint VERTEX_ARRAY_SIZE = 0x807A;
        public const uint VERTEX_ARRAY_TYPE = 0x807B;
        public const uint VERTEX_ARRAY_STRIDE = 0x807C;
        public const uint NORMAL_ARRAY_TYPE = 0x807E;
        public const uint NORMAL_ARRAY_STRIDE = 0x807F;
        public const uint COLOR_ARRAY_SIZE = 0x8081;
        public const uint COLOR_ARRAY_TYPE = 0x8082;
        public const uint COLOR_ARRAY_STRIDE = 0x8083;
        public const uint INDEX_ARRAY_TYPE = 0x8085;
        public const uint INDEX_ARRAY_STRIDE = 0x8086;
        public const uint TEXTURE_COORD_ARRAY_SIZE = 0x8088;
        public const uint TEXTURE_COORD_ARRAY_TYPE = 0x8089;
        public const uint TEXTURE_COORD_ARRAY_STRIDE = 0x808A;
        public const uint EDGE_FLAG_ARRAY_STRIDE = 0x808C;
        public const uint VERTEX_ARRAY_POINTER = 0x808E;
        public const uint NORMAL_ARRAY_POINTER = 0x808F;
        public const uint COLOR_ARRAY_POINTER = 0x8090;
        public const uint INDEX_ARRAY_POINTER = 0x8091;
        public const uint TEXTURE_COORD_ARRAY_POINTER = 0x8092;
        public const uint EDGE_FLAG_ARRAY_POINTER = 0x8093;
        public const uint COLOR_INDEX1_EXT = 0x80E2;
        public const uint COLOR_INDEX2_EXT = 0x80E3;
        public const uint COLOR_INDEX4_EXT = 0x80E4;
        public const uint COLOR_INDEX8_EXT = 0x80E5;
        public const uint COLOR_INDEX12_EXT = 0x80E6;
        public const uint COLOR_INDEX16_EXT = 0x80E7;
        public const uint EVAL_BIT = 0x00010000;
        public const uint LIST_BIT = 0x00020000;
        public const uint TEXTURE_BIT = 0x00040000;
        public const uint SCISSOR_BIT = 0x00080000;
        public const uint ALL_ATTRIB_BITS = 0x000fffff;
        public const uint CLIENT_ALL_ATTRIB_BITS = 0xffffffff;
    }
    public static class gl
    {
        [DllImport("OpenGL32.dll", EntryPoint = "glAccum")]
        public static extern void Accum(uint op, float value);
        [DllImport("OpenGL32.dll", EntryPoint = "glAlphaFunc")]
        public static extern void AlphaFunc(uint func, float vref);
        [DllImport("OpenGL32.dll", EntryPoint = "glAreTexturesResident")]
        public static extern byte AreTexturesResident(int n, uint[] textures, byte[] residences);
        [DllImport("OpenGL32.dll", EntryPoint = "glArrayElement")]
        public static extern void ArrayElement(int i);
        [DllImport("OpenGL32.dll", EntryPoint = "glBegin")]
        public static extern void Begin(uint mode);
        [DllImport("OpenGL32.dll", EntryPoint = "glBindTexture")]
        public static extern void BindTexture(uint target, uint texture);
        [DllImport("OpenGL32.dll", EntryPoint = "glBitmap")]
        public static extern void Bitmap(int width, int height, float xorig, float yorig, float xmove, float ymove, byte[] bitmap);
        [DllImport("OpenGL32.dll", EntryPoint = "glBlendFunc")]
        public static extern void BlendFunc(uint sfactor, uint dfactor);
        [DllImport("OpenGL32.dll", EntryPoint = "glCallList")]
        public static extern void CallList(uint list);
        [DllImport("OpenGL32.dll", EntryPoint = "glCallLists")]
        public static extern void CallLists(int n, uint type, IntPtr lists);
        [DllImport("OpenGL32.dll", EntryPoint = "glClear")]
        public static extern void Clear(uint mask);
        [DllImport("OpenGL32.dll", EntryPoint = "glClearAccum")]
        public static extern void ClearAccum(float red, float green, float blue, float alpha);
        [DllImport("OpenGL32.dll", EntryPoint = "glClearColor")]
        public static extern void ClearColor(float red, float green, float blue, float alpha);
        [DllImport("OpenGL32.dll", EntryPoint = "glClearDepth")]
        public static extern void ClearDepth(double depth);
        [DllImport("OpenGL32.dll", EntryPoint = "glClearIndex")]
        public static extern void ClearIndex(float c);
        [DllImport("OpenGL32.dll", EntryPoint = "glClearStencil")]
        public static extern void ClearStencil(int s);
        [DllImport("OpenGL32.dll", EntryPoint = "glClipPlane")]
        public static extern void ClipPlane(uint plane, double[] equation);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor3b")]
        public static extern void Color3b(sbyte red, sbyte green, sbyte blue);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor3bv")]
        public static extern void Color3bv(sbyte[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor3d")]
        public static extern void Color3d(double red, double green, double blue);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor3dv")]
        public static extern void Color3dv(double[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor3f")]
        public static extern void Color3f(float red, float green, float blue);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor3fv")]
        public static extern void Color3fv(float[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor3i")]
        public static extern void Color3i(int red, int green, int blue);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor3iv")]
        public static extern void Color3iv(int[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor3s")]
        public static extern void Color3s(short red, short green, short blue);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor3sv")]
        public static extern void Color3sv(short[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor3ub")]
        public static extern void Color3ub(byte red, byte green, byte blue);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor3ubv")]
        public static extern void Color3ubv(byte[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor3ui")]
        public static extern void Color3ui(uint red, uint green, uint blue);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor3uiv")]
        public static extern void Color3uiv(uint[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor3us")]
        public static extern void Color3us(ushort red, ushort green, ushort blue);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor3usv")]
        public static extern void Color3usv(ushort[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor4b")]
        public static extern void Color4b(sbyte red, sbyte green, sbyte blue, sbyte alpha);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor4bv")]
        public static extern void Color4bv(sbyte[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor4d")]
        public static extern void Color4d(double red, double green, double blue, double alpha);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor4dv")]
        public static extern void Color4dv(double[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor4f")]
        public static extern void Color4f(float red, float green, float blue, float alpha);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor4fv")]
        public static extern void Color4fv(float[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor4i")]
        public static extern void Color4i(int red, int green, int blue, int alpha);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor4iv")]
        public static extern void Color4iv(int[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor4s")]
        public static extern void Color4s(short red, short green, short blue, short alpha);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor4sv")]
        public static extern void Color4sv(short[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor4ub")]
        public static extern void Color4ub(byte red, byte green, byte blue, byte alpha);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor4ubv")]
        public static extern void Color4ubv(byte[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor4ui")]
        public static extern void Color4ui(uint red, uint green, uint blue, uint alpha);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor4uiv")]
        public static extern void Color4uiv(uint[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor4us")]
        public static extern void Color4us(ushort red, ushort green, ushort blue, ushort alpha);
        [DllImport("OpenGL32.dll", EntryPoint = "glColor4usv")]
        public static extern void Color4usv(ushort[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glColorMask")]
        public static extern void ColorMask(byte red, byte green, byte blue, byte alpha);
        [DllImport("OpenGL32.dll", EntryPoint = "glColorMaterial")]
        public static extern void ColorMaterial(uint face, uint mode);
        [DllImport("OpenGL32.dll", EntryPoint = "glColorPointer")]
        public static extern void ColorPointer(int size, uint type, int stride, IntPtr pointer);
        [DllImport("OpenGL32.dll", EntryPoint = "glCopyPixels")]
        public static extern void CopyPixels(int x, int y, int width, int height, uint type);
        [DllImport("OpenGL32.dll", EntryPoint = "glCopyTexImage1D")]
        public static extern void CopyTexImage1D(uint target, int level, uint internalFormat, int x, int y, int width, int border);
        [DllImport("OpenGL32.dll", EntryPoint = "glCopyTexImage2D")]
        public static extern void CopyTexImage2D(uint target, int level, uint internalFormat, int x, int y, int width, int height, int border);
        [DllImport("OpenGL32.dll", EntryPoint = "glCopyTexSubImage1D")]
        public static extern void CopyTexSubImage1D(uint target, int level, int xoffset, int x, int y, int width);
        [DllImport("OpenGL32.dll", EntryPoint = "glCopyTexSubImage2D")]
        public static extern void CopyTexSubImage2D(uint target, int level, int xoffset, int yoffset, int x, int y, int width, int height);
        [DllImport("OpenGL32.dll", EntryPoint = "glCullFace")]
        public static extern void CullFace(uint mode);
        [DllImport("OpenGL32.dll", EntryPoint = "glDeleteLists")]
        public static extern void DeleteLists(uint list, int range);
        [DllImport("OpenGL32.dll", EntryPoint = "glDeleteTextures")]
        public static extern void DeleteTextures(int n, uint[] textures);
        [DllImport("OpenGL32.dll", EntryPoint = "glDepthFunc")]
        public static extern void DepthFunc(uint func);
        [DllImport("OpenGL32.dll", EntryPoint = "glDepthMask")]
        public static extern void DepthMask(byte flag);
        [DllImport("OpenGL32.dll", EntryPoint = "glDepthRange")]
        public static extern void DepthRange(double zNear, double zFar);
        [DllImport("OpenGL32.dll", EntryPoint = "glDisable")]
        public static extern void Disable(uint cap);
        [DllImport("OpenGL32.dll", EntryPoint = "glDisableClientState")]
        public static extern void DisableClientState(uint array);
        [DllImport("OpenGL32.dll", EntryPoint = "glDrawArrays")]
        public static extern void DrawArrays(uint mode, int first, int count);
        [DllImport("OpenGL32.dll", EntryPoint = "glDrawBuffer")]
        public static extern void DrawBuffer(uint mode);
        [DllImport("OpenGL32.dll", EntryPoint = "glDrawElements")]
        public static extern void DrawElements(uint mode, int count, uint type, IntPtr indices);
        [DllImport("OpenGL32.dll", EntryPoint = "glDrawPixels")]
        public static extern void DrawPixels(int width, int height, uint format, uint type, IntPtr pixels);
        [DllImport("OpenGL32.dll", EntryPoint = "glEdgeFlag")]
        public static extern void EdgeFlag(byte flag);
        [DllImport("OpenGL32.dll", EntryPoint = "glEdgeFlagPointer")]
        public static extern void EdgeFlagPointer(int stride, IntPtr pointer);
        [DllImport("OpenGL32.dll", EntryPoint = "glEdgeFlagv")]
        public static extern void EdgeFlagv(byte[] flag);
        [DllImport("OpenGL32.dll", EntryPoint = "glEnable")]
        public static extern void Enable(uint cap);
        [DllImport("OpenGL32.dll", EntryPoint = "glEnableClientState")]
        public static extern void EnableClientState(uint array);
        [DllImport("OpenGL32.dll", EntryPoint = "glEnd")]
        public static extern void End();
        [DllImport("OpenGL32.dll", EntryPoint = "glEndList")]
        public static extern void EndList();
        [DllImport("OpenGL32.dll", EntryPoint = "glEvalCoord1d")]
        public static extern void EvalCoord1d(double u);
        [DllImport("OpenGL32.dll", EntryPoint = "glEvalCoord1dv")]
        public static extern void EvalCoord1dv(double[] u);
        [DllImport("OpenGL32.dll", EntryPoint = "glEvalCoord1f")]
        public static extern void EvalCoord1f(float u);
        [DllImport("OpenGL32.dll", EntryPoint = "glEvalCoord1fv")]
        public static extern void EvalCoord1fv(float[] u);
        [DllImport("OpenGL32.dll", EntryPoint = "glEvalCoord2d")]
        public static extern void EvalCoord2d(double u, double v);
        [DllImport("OpenGL32.dll", EntryPoint = "glEvalCoord2dv")]
        public static extern void EvalCoord2dv(double[] u);
        [DllImport("OpenGL32.dll", EntryPoint = "glEvalCoord2f")]
        public static extern void EvalCoord2f(float u, float v);
        [DllImport("OpenGL32.dll", EntryPoint = "glEvalCoord2fv")]
        public static extern void EvalCoord2fv(float[] u);
        [DllImport("OpenGL32.dll", EntryPoint = "glEvalMesh1")]
        public static extern void EvalMesh1(uint mode, int i1, int i2);
        [DllImport("OpenGL32.dll", EntryPoint = "glEvalMesh2")]
        public static extern void EvalMesh2(uint mode, int i1, int i2, int j1, int j2);
        [DllImport("OpenGL32.dll", EntryPoint = "glEvalPoint1")]
        public static extern void EvalPoint1(int i);
        [DllImport("OpenGL32.dll", EntryPoint = "glEvalPoint2")]
        public static extern void EvalPoint2(int i, int j);
        [DllImport("OpenGL32.dll", EntryPoint = "glFeedbackBuffer")]
        public static extern void FeedbackBuffer(int size, uint type, float[] buffer);
        [DllImport("OpenGL32.dll", EntryPoint = "glFinish")]
        public static extern void Finish();
        [DllImport("OpenGL32.dll", EntryPoint = "glFlush")]
        public static extern void Flush();
        [DllImport("OpenGL32.dll", EntryPoint = "glFogf")]
        public static extern void Fogf(uint pname, float param);
        [DllImport("OpenGL32.dll", EntryPoint = "glFogfv")]
        public static extern void Fogfv(uint pname, float[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glFogi")]
        public static extern void Fogi(uint pname, int param);
        [DllImport("OpenGL32.dll", EntryPoint = "glFogiv")]
        public static extern void Fogiv(uint pname, int[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glFrontFace")]
        public static extern void FrontFace(uint mode);
        [DllImport("OpenGL32.dll", EntryPoint = "glFrustum")]
        public static extern void Frustum(double left, double right, double bottom, double top, double zNear, double zFar);
        [DllImport("OpenGL32.dll", EntryPoint = "glGenLists")]
        public static extern uint GenLists(int range);
        [DllImport("OpenGL32.dll", EntryPoint = "glGenTextures")]
        public static extern void GenTextures(int n, uint[] textures);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetBooleanv")]
        public static extern void GetBooleanv(uint pname, byte[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetClipPlane")]
        public static extern void GetClipPlane(uint plane, double[] equation);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetDoublev")]
        public static extern void GetDoublev(uint pname, double[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetError")]
        public static extern uint GetError();
        [DllImport("OpenGL32.dll", EntryPoint = "glGetFloatv")]
        public static extern void GetFloatv(uint pname, float[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetIntegerv")]
        public static extern void GetIntegerv(uint pname, int[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetLightfv")]
        public static extern void GetLightfv(uint light, uint pname, float[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetLightiv")]
        public static extern void GetLightiv(uint light, uint pname, int[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetMapdv")]
        public static extern void GetMapdv(uint target, uint query, double[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetMapfv")]
        public static extern void GetMapfv(uint target, uint query, float[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetMapiv")]
        public static extern void GetMapiv(uint target, uint query, int[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetMaterialfv")]
        public static extern void GetMaterialfv(uint face, uint pname, float[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetMaterialiv")]
        public static extern void GetMaterialiv(uint face, uint pname, int[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetPixelMapfv")]
        public static extern void GetPixelMapfv(uint map, float[] values);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetPixelMapuiv")]
        public static extern void GetPixelMapuiv(uint map, uint[] values);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetPixelMapusv")]
        public static extern void GetPixelMapusv(uint map, ushort[] values);
        //[DllImport("OpenGL32.dll", EntryPoint = "glGetPointerv")]
        //public static extern void GetPointerv(uint pname, void**args);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetPolygonStipple")]
        public static extern void GetPolygonStipple(byte[] mask);
        //[DllImport("OpenGL32.dll", EntryPoint = "")]
        //public static extern const byte* GetString(uint name);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetTexEnvfv")]
        public static extern void GetTexEnvfv(uint target, uint pname, float[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetTexEnviv")]
        public static extern void GetTexEnviv(uint target, uint pname, int[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetTexGendv")]
        public static extern void GetTexGendv(uint coord, uint pname, double[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetTexGenfv")]
        public static extern void GetTexGenfv(uint coord, uint pname, float[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetTexGeniv")]
        public static extern void GetTexGeniv(uint coord, uint pname, int[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetTexImage")]
        public static extern void GetTexImage(uint target, int level, uint format, uint type, out IntPtr pixels);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetTexLevelParameterfv")]
        public static extern void GetTexLevelParameterfv(uint target, int level, uint pname, float[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetTexLevelParameteriv")]
        public static extern void GetTexLevelParameteriv(uint target, int level, uint pname, int[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetTexParameterfv")]
        public static extern void GetTexParameterfv(uint target, uint pname, float[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glGetTexParameteriv")]
        public static extern void GetTexParameteriv(uint target, uint pname, int[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glHint")]
        public static extern void Hint(uint target, uint mode);
        [DllImport("OpenGL32.dll", EntryPoint = "glIndexMask")]
        public static extern void IndexMask(uint mask);
        [DllImport("OpenGL32.dll", EntryPoint = "glIndexPointer")]
        public static extern void IndexPointer(uint type, int stride, IntPtr pointer);
        [DllImport("OpenGL32.dll", EntryPoint = "glIndexd")]
        public static extern void Indexd(double c);
        [DllImport("OpenGL32.dll", EntryPoint = "glIndexdv")]
        public static extern void Indexdv(double[] c);
        [DllImport("OpenGL32.dll", EntryPoint = "glIndexf")]
        public static extern void Indexf(float c);
        [DllImport("OpenGL32.dll", EntryPoint = "glIndexfv")]
        public static extern void Indexfv(float[] c);
        [DllImport("OpenGL32.dll", EntryPoint = "glIndexi")]
        public static extern void Indexi(int c);
        [DllImport("OpenGL32.dll", EntryPoint = "glIndexiv")]
        public static extern void Indexiv(int[] c);
        [DllImport("OpenGL32.dll", EntryPoint = "glIndexs")]
        public static extern void Indexs(short c);
        [DllImport("OpenGL32.dll", EntryPoint = "glIndexsv")]
        public static extern void Indexsv(short[] c);
        [DllImport("OpenGL32.dll", EntryPoint = "glIndexub")]
        public static extern void Indexub(byte c);
        [DllImport("OpenGL32.dll", EntryPoint = "glIndexubv")]
        public static extern void Indexubv(byte c);
        [DllImport("OpenGL32.dll", EntryPoint = "glInitNames")]
        public static extern void InitNames();
        [DllImport("OpenGL32.dll", EntryPoint = "interleavedArrays")]
        public static extern void interleavedArrays(uint format, int stride, IntPtr pointer);
        [DllImport("OpenGL32.dll", EntryPoint = "glIsEnabled")]
        public static extern byte IsEnabled(uint cap);
        [DllImport("OpenGL32.dll", EntryPoint = "glIsList")]
        public static extern byte IsList(uint list);
        [DllImport("OpenGL32.dll", EntryPoint = "glIsTexture")]
        public static extern byte IsTexture(uint texture);
        [DllImport("OpenGL32.dll", EntryPoint = "glLightModelf")]
        public static extern void LightModelf(uint pname, float param);
        [DllImport("OpenGL32.dll", EntryPoint = "glLightModelfv")]
        public static extern void LightModelfv(uint pname, float[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glLightModeli")]
        public static extern void LightModeli(uint pname, int param);
        [DllImport("OpenGL32.dll", EntryPoint = "glLightModeliv")]
        public static extern void LightModeliv(uint pname, int[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glLightf")]
        public static extern void Lightf(uint light, uint pname, float param);
        [DllImport("OpenGL32.dll", EntryPoint = "glLightfv")]
        public static extern void Lightfv(uint light, uint pname, float[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glLighti")]
        public static extern void Lighti(uint light, uint pname, int param);
        [DllImport("OpenGL32.dll", EntryPoint = "glLightiv")]
        public static extern void Lightiv(uint light, uint pname, int[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glLineStipple")]
        public static extern void LineStipple(int factor, ushort pattern);
        [DllImport("OpenGL32.dll", EntryPoint = "glLineWidth")]
        public static extern void LineWidth(float width);
        [DllImport("OpenGL32.dll", EntryPoint = "glListBase")]
        public static extern void ListBase(uint b);
        [DllImport("OpenGL32.dll", EntryPoint = "glLoadIdentity")]
        public static extern void LoadIdentity();
        [DllImport("OpenGL32.dll", EntryPoint = "glLoadMatrixd")]
        public static extern void LoadMatrixd(double[] m);
        [DllImport("OpenGL32.dll", EntryPoint = "glLoadMatrixf")]
        public static extern void LoadMatrixf(float[] m);
        [DllImport("OpenGL32.dll", EntryPoint = "glLoadName")]
        public static extern void LoadName(uint name);
        [DllImport("OpenGL32.dll", EntryPoint = "glLogicOp")]
        public static extern void LogicOp(uint opcode);
        [DllImport("OpenGL32.dll", EntryPoint = "glMap1d")]
        public static extern void Map1d(uint target, double u1, double u2, int stride, int order, double[] points);
        [DllImport("OpenGL32.dll", EntryPoint = "glMap1f")]
        public static extern void Map1f(uint target, float u1, float u2, int stride, int order, float[] points);
        [DllImport("OpenGL32.dll", EntryPoint = "glMap2d")]
        public static extern void Map2d(uint target, double u1, double u2, int ustride, int uorder, double v1, double v2, int vstride, int vorder, double[] points);
        [DllImport("OpenGL32.dll", EntryPoint = "glMap2f")]
        public static extern void Map2f(uint target, float u1, float u2, int ustride, int uorder, float v1, float v2, int vstride, int vorder, float[] points);
        [DllImport("OpenGL32.dll", EntryPoint = "glMapGrid1d")]
        public static extern void MapGrid1d(int un, double u1, double u2);
        [DllImport("OpenGL32.dll", EntryPoint = "glMapGrid1f")]
        public static extern void MapGrid1f(int un, float u1, float u2);
        [DllImport("OpenGL32.dll", EntryPoint = "glMapGrid2d")]
        public static extern void MapGrid2d(int un, double u1, double u2, int vn, double v1, double v2);
        [DllImport("OpenGL32.dll", EntryPoint = "glMapGrid2f")]
        public static extern void MapGrid2f(int un, float u1, float u2, int vn, float v1, float v2);
        [DllImport("OpenGL32.dll", EntryPoint = "glMaterialf")]
        public static extern void Materialf(uint face, uint pname, float param);
        [DllImport("OpenGL32.dll", EntryPoint = "glMaterialfv")]
        public static extern void Materialfv(uint face, uint pname, float[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glMateriali")]
        public static extern void Materiali(uint face, uint pname, int param);
        [DllImport("OpenGL32.dll", EntryPoint = "glMaterialiv")]
        public static extern void Materialiv(uint face, uint pname, int[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glMatrixMode")]
        public static extern void MatrixMode(uint mode);
        [DllImport("OpenGL32.dll", EntryPoint = "glMultMatrixd")]
        public static extern void MultMatrixd(double[] m);
        [DllImport("OpenGL32.dll", EntryPoint = "glMultMatrixf")]
        public static extern void MultMatrixf(float[] m);
        [DllImport("OpenGL32.dll", EntryPoint = "glNewList")]
        public static extern void NewList(uint list, uint mode);
        [DllImport("OpenGL32.dll", EntryPoint = "glNormal3b")]
        public static extern void Normal3b(sbyte nx, sbyte ny, sbyte nz);
        [DllImport("OpenGL32.dll", EntryPoint = "glNormal3bv")]
        public static extern void Normal3bv(sbyte[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glNormal3d")]
        public static extern void Normal3d(double nx, double ny, double nz);
        [DllImport("OpenGL32.dll", EntryPoint = "glNormal3dv")]
        public static extern void Normal3dv(double[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glNormal3f")]
        public static extern void Normal3f(float nx, float ny, float nz);
        [DllImport("OpenGL32.dll", EntryPoint = "glNormal3fv")]
        public static extern void Normal3fv(float[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glNormal3i")]
        public static extern void Normal3i(int nx, int ny, int nz);
        [DllImport("OpenGL32.dll", EntryPoint = "glNormal3iv")]
        public static extern void Normal3iv(int[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glNormal3s")]
        public static extern void Normal3s(short nx, short ny, short nz);
        [DllImport("OpenGL32.dll", EntryPoint = "glNormal3sv")]
        public static extern void Normal3sv(short[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glNormalPointer")]
        public static extern void NormalPointer(uint type, int stride, IntPtr pointer);
        [DllImport("OpenGL32.dll", EntryPoint = "glOrtho")]
        public static extern void Ortho(double left, double right, double bottom, double top, double zNear, double zFar);
        [DllImport("OpenGL32.dll", EntryPoint = "glPassThrough")]
        public static extern void PassThrough(float token);
        [DllImport("OpenGL32.dll", EntryPoint = "glPixelMapfv")]
        public static extern void PixelMapfv(uint map, int mapsize, float[] values);
        [DllImport("OpenGL32.dll", EntryPoint = "EntryPoint")]
        public static extern void PixelMapuiv(uint map, int mapsize, uint[] values);
        [DllImport("OpenGL32.dll", EntryPoint = "glPixelMapusv")]
        public static extern void PixelMapusv(uint map, int mapsize, ushort[] values);
        [DllImport("OpenGL32.dll", EntryPoint = "glPixelStoref")]
        public static extern void PixelStoref(uint pname, float param);
        [DllImport("OpenGL32.dll", EntryPoint = "glPixelStorei")]
        public static extern void PixelStorei(uint pname, int param);
        [DllImport("OpenGL32.dll", EntryPoint = "glPixelTransferf")]
        public static extern void PixelTransferf(uint pname, float param);
        [DllImport("OpenGL32.dll", EntryPoint = "glPixelTransferi")]
        public static extern void PixelTransferi(uint pname, int param);
        [DllImport("OpenGL32.dll", EntryPoint = "glPixelZoom")]
        public static extern void PixelZoom(float xfactor, float yfactor);
        [DllImport("OpenGL32.dll", EntryPoint = "glPointSize")]
        public static extern void PointSize(float size);
        [DllImport("OpenGL32.dll", EntryPoint = "glPolygonMode")]
        public static extern void PolygonMode(uint face, uint mode);
        [DllImport("OpenGL32.dll", EntryPoint = "glPolygonOffset")]
        public static extern void PolygonOffset(float factor, float units);
        [DllImport("OpenGL32.dll", EntryPoint = "glPolygonStipple")]
        public static extern void PolygonStipple(byte[] mask);
        [DllImport("OpenGL32.dll", EntryPoint = "glPopAttrib")]
        public static extern void PopAttrib();
        [DllImport("OpenGL32.dll", EntryPoint = "glPopClientAttrib")]
        public static extern void PopClientAttrib();
        [DllImport("OpenGL32.dll", EntryPoint = "glPopMatrix")]
        public static extern void PopMatrix();
        [DllImport("OpenGL32.dll", EntryPoint = "glPopName")]
        public static extern void PopName();
        [DllImport("OpenGL32.dll", EntryPoint = "glPrioritizeTextures")]
        public static extern void PrioritizeTextures(int n, uint[] textures, float[] priorities);
        [DllImport("OpenGL32.dll", EntryPoint = "glPushAttrib")]
        public static extern void PushAttrib(uint mask);
        [DllImport("OpenGL32.dll", EntryPoint = "glPushClientAttrib")]
        public static extern void PushClientAttrib(uint mask);
        [DllImport("OpenGL32.dll", EntryPoint = "glPushMatrix")]
        public static extern void PushMatrix();
        [DllImport("OpenGL32.dll", EntryPoint = "glPushName")]
        public static extern void PushName(uint name);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos2d")]
        public static extern void RasterPos2d(double x, double y);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos2dv")]
        public static extern void RasterPos2dv(double[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos2f")]
        public static extern void RasterPos2f(float x, float y);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos2fv")]
        public static extern void RasterPos2fv(float[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos2i")]
        public static extern void RasterPos2i(int x, int y);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos2iv")]
        public static extern void RasterPos2iv(int[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos2s")]
        public static extern void RasterPos2s(short x, short y);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos2sv")]
        public static extern void RasterPos2sv(short[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos3d")]
        public static extern void RasterPos3d(double x, double y, double z);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos3dv")]
        public static extern void RasterPos3dv(double[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos3f")]
        public static extern void RasterPos3f(float x, float y, float z);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos3fv")]
        public static extern void RasterPos3fv(float[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos3i")]
        public static extern void RasterPos3i(int x, int y, int z);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos3iv")]
        public static extern void RasterPos3iv(int[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos3s")]
        public static extern void RasterPos3s(short x, short y, short z);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos3sv")]
        public static extern void RasterPos3sv(short[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos4d")]
        public static extern void RasterPos4d(double x, double y, double z, double w);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos4dv")]
        public static extern void RasterPos4dv(double[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos4f")]
        public static extern void RasterPos4f(float x, float y, float z, float w);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos4fv")]
        public static extern void RasterPos4fv(float[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos4i")]
        public static extern void RasterPos4i(int x, int y, int z, int w);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos4iv")]
        public static extern void RasterPos4iv(int[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos4s")]
        public static extern void RasterPos4s(short x, short y, short z, short w);
        [DllImport("OpenGL32.dll", EntryPoint = "glRasterPos4sv")]
        public static extern void RasterPos4sv(short[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glReadBuffer")]
        public static extern void ReadBuffer(uint mode);
        [DllImport("OpenGL32.dll", EntryPoint = "glReadPixels")]
        public static extern void ReadPixels(int x, int y, int width, int height, uint format, uint type, out IntPtr pixels);
        [DllImport("OpenGL32.dll", EntryPoint = "glRectd")]
        public static extern void Rectd(double x1, double y1, double x2, double y2);
        [DllImport("OpenGL32.dll", EntryPoint = "glRectdv")]
        public static extern void Rectdv(double[] v1, double[] v2);
        [DllImport("OpenGL32.dll", EntryPoint = "glRectf")]
        public static extern void Rectf(float x1, float y1, float x2, float y2);
        [DllImport("OpenGL32.dll", EntryPoint = "glRectfv")]
        public static extern void Rectfv(float[] v1, float[] v2);
        [DllImport("OpenGL32.dll", EntryPoint = "glRecti")]
        public static extern void Recti(int x1, int y1, int x2, int y2);
        [DllImport("OpenGL32.dll", EntryPoint = "glRectiv")]
        public static extern void Rectiv(int[] v1, int[] v2);
        [DllImport("OpenGL32.dll", EntryPoint = "glRects")]
        public static extern void Rects(short x1, short y1, short x2, short y2);
        [DllImport("OpenGL32.dll", EntryPoint = "glRectsv")]
        public static extern void Rectsv(short[] v1, short[] v2);
        [DllImport("OpenGL32.dll", EntryPoint = "glRenderMode")]
        public static extern int RenderMode(uint mode);
        [DllImport("OpenGL32.dll", EntryPoint = "glRotated")]
        public static extern void Rotated(double angle, double x, double y, double z);
        [DllImport("OpenGL32.dll", EntryPoint = "glRotatef")]
        public static extern void Rotatef(float angle, float x, float y, float z);
        [DllImport("OpenGL32.dll", EntryPoint = "glScaled")]
        public static extern void Scaled(double x, double y, double z);
        [DllImport("OpenGL32.dll", EntryPoint = "glScalef")]
        public static extern void Scalef(float x, float y, float z);
        [DllImport("OpenGL32.dll", EntryPoint = "glScissor")]
        public static extern void Scissor(int x, int y, int width, int height);
        [DllImport("OpenGL32.dll", EntryPoint = "glSelectBuffer")]
        public static extern void SelectBuffer(int size, uint[] buffer);
        [DllImport("OpenGL32.dll", EntryPoint = "glShadeModel")]
        public static extern void ShadeModel(uint mode);
        [DllImport("OpenGL32.dll", EntryPoint = "glStencilFunc")]
        public static extern void StencilFunc(uint func, int vref, uint mask);
        [DllImport("OpenGL32.dll", EntryPoint = "glStencilMask")]
        public static extern void StencilMask(uint mask);
        [DllImport("OpenGL32.dll", EntryPoint = "glStencilOp")]
        public static extern void StencilOp(uint fail, uint zfail, uint zpass);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord1d")]
        public static extern void TexCoord1d(double s);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord1dv")]
        public static extern void TexCoord1dv(double[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord1f")]
        public static extern void TexCoord1f(float s);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord1fv")]
        public static extern void TexCoord1fv(float[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord1i")]
        public static extern void TexCoord1i(int s);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord1iv")]
        public static extern void TexCoord1iv(int[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord1s")]
        public static extern void TexCoord1s(short s);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord1sv")]
        public static extern void TexCoord1sv(short[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord2d")]
        public static extern void TexCoord2d(double s, double t);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord2dv")]
        public static extern void TexCoord2dv(double[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord2f")]
        public static extern void TexCoord2f(float s, float t);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord2fv")]
        public static extern void TexCoord2fv(float[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord2i")]
        public static extern void TexCoord2i(int s, int t);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord2iv")]
        public static extern void TexCoord2iv(int[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord2s")]
        public static extern void TexCoord2s(short s, short t);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord2sv")]
        public static extern void TexCoord2sv(short[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord3d")]
        public static extern void TexCoord3d(double s, double t, double r);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord3dv")]
        public static extern void TexCoord3dv(double[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord3f")]
        public static extern void TexCoord3f(float s, float t, float r);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord3fv")]
        public static extern void TexCoord3fv(float[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord3i")]
        public static extern void TexCoord3i(int s, int t, int r);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord3iv")]
        public static extern void TexCoord3iv(int[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord3s")]
        public static extern void TexCoord3s(short s, short t, short r);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord3sv")]
        public static extern void TexCoord3sv(short[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord4d")]
        public static extern void TexCoord4d(double s, double t, double r, double q);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord4dv")]
        public static extern void TexCoord4dv(double[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord4f")]
        public static extern void TexCoord4f(float s, float t, float r, float q);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord4fv")]
        public static extern void TexCoord4fv(float[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord4i")]
        public static extern void TexCoord4i(int s, int t, int r, int q);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord4iv")]
        public static extern void TexCoord4iv(int[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord4s")]
        public static extern void TexCoord4s(short s, short t, short r, short q);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoord4sv")]
        public static extern void TexCoord4sv(short[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexCoordPointer")]
        public static extern void TexCoordPointer(int size, uint type, int stride, IntPtr pointer);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexEnvf")]
        public static extern void TexEnvf(uint target, uint pname, float arg);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexEnvfv")]
        public static extern void TexEnvfv(uint target, uint pname, float[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexEnvi")]
        public static extern void TexEnvi(uint target, uint pname, int arg);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexEnviv")]
        public static extern void TexEnviv(uint target, uint pname, int[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexGend")]
        public static extern void TexGend(uint coord, uint pname, double param);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexGendv")]
        public static extern void TexGendv(uint coord, uint pname, double[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexGenf")]
        public static extern void TexGenf(uint coord, uint pname, float param);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexGenfv")]
        public static extern void TexGenfv(uint coord, uint pname, float[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexGeni")]
        public static extern void TexGeni(uint coord, uint pname, int param);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexGeniv")]
        public static extern void TexGeniv(uint coord, uint pname, int[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexImage1D")]
        public static extern void TexImage1D(uint target, int level, int internalformat, int width, int border, uint format, uint type, IntPtr pixels);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexImage2D")]
        public static extern void TexImage2D(uint target, int level, int internalformat, int width, int height, int border, uint format, uint type, IntPtr pixels);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexParameterf")]
        public static extern void TexParameterf(uint target, uint pname, float param);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexParameterfv")]
        public static extern void TexParameterfv(uint target, uint pname, float[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexParameteri")]
        public static extern void TexParameteri(uint target, uint pname, int param);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexParameteriv")]
        public static extern void TexParameteriv(uint target, uint pname, int[] args);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexSubImage1D")]
        public static extern void TexSubImage1D(uint target, int level, int xoffset, int width, uint format, uint type, IntPtr pixels);
        [DllImport("OpenGL32.dll", EntryPoint = "glTexSubImage2D")]
        public static extern void TexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, IntPtr pixels);
        [DllImport("OpenGL32.dll", EntryPoint = "glTranslated")]
        public static extern void Translated(double x, double y, double z);
        [DllImport("OpenGL32.dll", EntryPoint = "glTranslatef")]
        public static extern void Translatef(float x, float y, float z);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex2d")]
        public static extern void Vertex2d(double x, double y);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex2dv")]
        public static extern void Vertex2dv(double[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex2f")]
        public static extern void Vertex2f(float x, float y);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex2fv")]
        public static extern void Vertex2fv(float[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex2i")]
        public static extern void Vertex2i(int x, int y);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex2iv")]
        public static extern void Vertex2iv(int[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex2s")]
        public static extern void Vertex2s(short x, short y);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex2sv")]
        public static extern void Vertex2sv(short[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex3d")]
        public static extern void Vertex3d(double x, double y, double z);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex3dv")]
        public static extern void Vertex3dv(double[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex3f")]
        public static extern void Vertex3f(float x, float y, float z);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex3fv")]
        public static extern void Vertex3fv(float[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex3i")]
        public static extern void Vertex3i(int x, int y, int z);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex3iv")]
        public static extern void Vertex3iv(int[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex3s")]
        public static extern void Vertex3s(short x, short y, short z);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex3sv")]
        public static extern void Vertex3sv(short[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex4d")]
        public static extern void Vertex4d(double x, double y, double z, double w);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex4dv")]
        public static extern void Vertex4dv(double[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex4f")]
        public static extern void Vertex4f(float x, float y, float z, float w);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex4fv")]
        public static extern void Vertex4fv(float[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex4i")]
        public static extern void Vertex4i(int x, int y, int z, int w);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex4iv")]
        public static extern void Vertex4iv(int[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex4s")]
        public static extern void Vertex4s(short x, short y, short z, short w);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertex4sv")]
        public static extern void Vertex4sv(short[] v);
        [DllImport("OpenGL32.dll", EntryPoint = "glVertexPointer")]
        public static extern void VertexPointer(int size, uint type, int stride, IntPtr pointer);
        [DllImport("OpenGL32.dll", EntryPoint = "glViewport")]
        public static extern void Viewport(int x, int y, int width, int height);

        public static uint GenTexture()
        {
            uint[] t = new uint[1];
            GenTextures(1, t);
            return t[0];
        }
        public static void DeleteTexture(uint t)
        {
            uint[] at = new uint[1];
            at[0] = t;
            DeleteTextures(1, at);
        }
    }
    public static class wgl
    {
        [DllImport("OpenGL32.dll", EntryPoint = "wglCopyContext")]
        public static extern bool CopyContext(IntPtr hglrc0, IntPtr hglrc1, uint p);
        [DllImport("OpenGL32.dll", EntryPoint = "wglCreateContext")]
        public static extern IntPtr CreateContext(IntPtr hdc);
        [DllImport("OpenGL32.dll", EntryPoint = "wglCreateLayerContext")]
        public static extern IntPtr CreateLayerContext(IntPtr hdc, int l);
        [DllImport("OpenGL32.dll", EntryPoint = "wglDeleteContext")]
        public static extern bool DeleteContext(IntPtr hglrc);
        [DllImport("OpenGL32.dll", EntryPoint = "wglGetCurrentContext")]
        public static extern IntPtr GetCurrentContext();
        [DllImport("OpenGL32.dll", EntryPoint = "wglGetCurrentDC")]
        public static extern IntPtr GetCurrentDC();
        [DllImport("OpenGL32.dll", EntryPoint = "wglMakeCurrent")]
        public static extern bool MakeCurrent(IntPtr hdc, IntPtr hglrc);
        [DllImport("OpenGL32.dll", EntryPoint = "wglShareLists")]
        public static extern bool ShareLists(IntPtr hglrc0, IntPtr hglrc1);
        [DllImport("OpenGL32.dll", EntryPoint = "wglUseFontBitmapsA")]
        public static extern bool UseFontBitmapsA(IntPtr hdc, uint x, uint y, uint z);
        [DllImport("OpenGL32.dll", EntryPoint = "wglUseFontBitmapsW")]
        public static extern bool UseFontBitmapsW(IntPtr hdc, uint x, uint y, uint z);
    }
    public static class gdi
    {
        public const byte PFD_TYPE_RGBA = 0x00000000;
        public const byte PFD_TYPE_COLORINDEX = 0x00000001;

        public const uint PFD_DOUBLEBUFFER = 0x00000001;
        public const uint PFD_STEREO = 0x00000002;
        public const uint PFD_DRAW_TO_WINDOW = 0x00000004;
        public const uint PFD_DRAW_TO_BITMAP = 0x00000008;
        public const uint PFD_SUPPORT_GDI = 0x00000010;
        public const uint PFD_SUPPORT_OPENGL = 0x00000020;
        public const uint PFD_GENERIC_FORMAT = 0x00000040;
        public const uint PFD_NEED_PALETTE = 0x00000080;
        public const uint PFD_NEED_SYSTEM_PALETTE = 0x00000100;
        public const uint PFD_SWAP_EXCHANGE = 0x00000200;
        public const uint PFD_SWAP_COPY = 0x00000400;
        public const uint PFD_SWAP_LAYER_BUFFERS = 0x00000800;
        public const uint PFD_GENERIC_ACCELERATED = 0x00001000;
        public const uint PFD_SUPPORT_DIRECTDRAW = 0x00002000;
        public const uint PFD_DIRECT3D_ACCELERATED = 0x00004000;
        public const uint PFD_SUPPORT_COMPOSITION = 0x00008000;

        public struct PIXELFORMATDESCRIPTOR
        {
            public ushort nSize;
            public ushort nVersion;
            public uint dwFlags;
            public byte iPixelType;
            public byte cColorBits;
            public byte cRedBits;
            public byte cRedShift;
            public byte cGreenBits;
            public byte cGreenShift;
            public byte cBlueBits;
            public byte cBlueShift;
            public byte cAlphaBits;
            public byte cAlphaShift;
            public byte cAccumBits;
            public byte cAccumRedBits;
            public byte cAccumGreenBits;
            public byte cAccumBlueBits;
            public byte cAccumAlphaBits;
            public byte cDepthBits;
            public byte cStencilBits;
            public byte cAuxBuffers;
            public byte iLayerType;
            public byte bReserved;
            public uint dwLayerMask;
            public uint dwVisibleMask;
            public uint dwDamageMask;
        }

        [DllImport("User32.dll", EntryPoint = "GetDC")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll", EntryPoint = "ReleaseDC")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);
        [DllImport("Gdi32.dll", EntryPoint = "ChoosePixelFormat")]
        public static extern int ChoosePixelFormat(IntPtr hdc, out PIXELFORMATDESCRIPTOR pfd);
        [DllImport("Gdi32.dll", EntryPoint = "SetPixelFormat")]
        public static extern bool SetPixelFormat(IntPtr hdc, int format, out PIXELFORMATDESCRIPTOR pfd);
        [DllImport("Gdi32.dll", EntryPoint = "SwapBuffers")]
        public static extern bool SwapBuffers(IntPtr hdc);
    }
    public static class fgl
    {
        public static uint ToGLTexture(this Bitmap bmp)
        {
            if (bmp == null) return 0;
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            uint texture = gl.GenTexture();
            gl.BindTexture(GL.TEXTURE_2D, texture);
            gl.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_MAG_FILTER, GL.NEAREST);
            gl.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_MIN_FILTER, GL.NEAREST);
            gl.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_WRAP_S, GL.CLAMP);
            gl.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_WRAP_T, GL.CLAMP);
            gl.TexImage2D(GL.TEXTURE_2D, 0, GL.RGBA, bmp.Width, bmp.Height, 0, 0x80e1, GL.UNSIGNED_BYTE, data.Scan0);
            bmp.UnlockBits(data);
            return texture;
        }
        public static uint BitmapToGLTexture(Bitmap bmp)
        {
            if (bmp == null) return 0;
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            uint texture = gl.GenTexture();
            gl.BindTexture(GL.TEXTURE_2D, texture);
            gl.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_MAG_FILTER, GL.NEAREST);
            gl.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_MIN_FILTER, GL.NEAREST);
            gl.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_WRAP_S, GL.CLAMP);
            gl.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_WRAP_T, GL.CLAMP);
            gl.TexImage2D(GL.TEXTURE_2D, 0, GL.RGBA, bmp.Width, bmp.Height, 0, 0x80e1, GL.UNSIGNED_BYTE, data.Scan0);
            bmp.UnlockBits(data);
            return texture;
        }
    }
}
